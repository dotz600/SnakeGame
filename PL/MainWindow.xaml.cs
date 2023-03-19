using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// by clicking on the start button the game will start.
/// BackgroundWorker will start and will do all the work,
/// from update the screen to move the snake exe/
/// in the mean time we have 2 threads that will handle the speed of the snake 
/// and the candy refresh - to keep the game interesting.
/// game over is when the snake hit the wall or himself.
/// player can use the arrow keys to move the snake
/// </summary>
public partial class MainWindow : Window
{
    readonly BlApi.IBL bl = new BLimplementation.BL();

    readonly BackgroundWorker worker = new();

    readonly Thread handleSpeed;//the thread determines the speed of the snake using speed

    readonly Thread candyRefresh;//in charge on refresh candy list every 10 sec

    readonly int MaxCoordinate;//hold the size of the window - from BL from Dal

    int speed = 100;

    public volatile bool isGameOn;

    BO.Snake snk;

    BO.Candy cnd;

    BO.Direction? dir;//direction of the snake
    
    //for candy image
    readonly string source = "C:\\Users\\ohevd\\source\\repos\\Snake\\PL\\Image\\dollar.png";

    public MainWindow()
    {
        InitializeComponent();
        MaxCoordinate = bl.Snake.GetMaxCoordinate();
        this.Width = MaxCoordinate;
        this.Height = MaxCoordinate;
        
        snk = bl.Snake.Read();
        cnd = bl.Candy.Read();

        //set threads
        handleSpeed = new(SetSpeed);
        candyRefresh = new(SetRefresh);
        //subscribe to the event in bl
        BLimplementation.Snake.CandyEatenEvent += Snake_CandyEatenEvent;
 
        worker.DoWork += Worker_DoWork;
        worker.ProgressChanged += ScreenUpdateControl;
        worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

        worker.WorkerReportsProgress = true;
        worker.WorkerSupportsCancellation = true;
        isGameOn = true;
    }


    /// <summary>
    /// start game button click.
    /// first Initialize snake body and candy on screen.
    /// start snakeSpeed & candy refresh thread
    /// start worker
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        myCanvas.Children.Remove(startButton);

        //Initialize snake body on screen 
        foreach (var p in snk.SnakeBody!)
            CreateEllipse(p);

        //initialize candys on screen
        foreach (var c in cnd.CandysOnMap!)
            CreateImage(c);

        //start the threades & the worker
        candyRefresh.Start();
        handleSpeed.Start();
        worker.RunWorkerAsync();
    }


    /// <summary>
    /// this function do all the work that need to be done
    /// while game is on
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Worker_DoWork(object? sender, DoWorkEventArgs e)
    {
        while (isGameOn)
        {
            if (bl.Snake.IsGameOn())
            {
                snk = bl.Snake.UpdateMove(dir);
                worker.ReportProgress(1);//update snake coordinate on screen
                Thread.Sleep(speed);//startSpeed will decrease acoording to game progresses
            }
            else
            {
                isGameOn = false;
                MessageBox.Show("Game Over", "Your Snake Is Dead", MessageBoxButton.OK, MessageBoxImage.Exclamation
                , MessageBoxResult.OK);
                worker.CancelAsync();
            }
        }
    }


    /// <summary>
    /// in charge for update the screen
    /// if calld with 1, update snake
    /// else update candy
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScreenUpdateControl(object? sender, ProgressChangedEventArgs e)
    {
        if (e.ProgressPercentage == 1)
            UpdateSnakeOnScreen();
        else
            UpdateCandyesOnScreen();
    }


    /// <summary>
    /// determines what to do when game over
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        handleSpeed.Join();
        candyRefresh.Join();
        worker.DoWork -= Worker_DoWork;
        worker.ProgressChanged -= ScreenUpdateControl;
        worker.RunWorkerCompleted -= Worker_RunWorkerCompleted;
        BLimplementation.Snake.CandyEatenEvent -= Snake_CandyEatenEvent;
        this.Close();
    }


    /// <summary>
    /// when candy eaten bl rise event and get to here
    /// read the new candy and update screen
    /// </summary>
    private void Snake_CandyEatenEvent()
    {
        cnd = bl.Candy.Read();
        worker.ReportProgress(0);
    }


    /// <summary>
    /// for each element in the screen
    /// if its Candy(Image) update its coordinate
    /// </summary>
    private void UpdateCandyesOnScreen()
    {
        int j = 0;
        for (int i = 0; i < myCanvas.Children.Count; i++)
        {
            if (myCanvas.Children[i] is Image)
            {
                Canvas.SetLeft(myCanvas.Children[i], cnd.CandysOnMap![j].X);
                Canvas.SetTop(myCanvas.Children[i], cnd.CandysOnMap![j].Y);
                j++;
            }
        }
    }


    /// <summary>
    /// for each element in the screen
    /// if its part of the snake(ellipse) update its coordinate
    /// if the snake has grown add the new parts of the snake
    /// </summary>
    private void UpdateSnakeOnScreen()
    {
        int counter = 0;
        for (int i = 0; i < myCanvas.Children.Count; i++)
        {
            if (myCanvas.Children[i] is Ellipse)
            {
                Canvas.SetLeft(myCanvas.Children[i], snk.SnakeBody![counter].X);
                Canvas.SetTop(myCanvas.Children[i], snk.SnakeBody![counter].Y);
                counter++;
            }
        }
        while (counter < snk.SnakeBody!.Count)
            CreateEllipse(snk.SnakeBody[counter++]);
    }


    /// <summary>
    /// create image that represent candy
    /// and add it to canvas
    /// </summary>
    /// <param name="candy"></param>
    private void CreateImage(BO.Point candy)
    {
        Image img = new()
        {
            Source = new BitmapImage(new Uri(source)),
            Height = 10,
            Width = 10,

        };
        Canvas.SetLeft(img, candy.X);
        Canvas.SetTop(img, candy.Y);
        myCanvas.Children.Add(img);
    }


    /// <summary>
    /// create nre ellipse that represnt part of the snake
    /// in the coordinate of p, and add it to canvas
    /// the first point is add by res color
    /// </summary>
    /// <param name="p"></param>
    private void CreateEllipse(BO.Point p)
    {
        Ellipse ellipse = new()
        {
            Width = 10,
            Height = 10,
            Fill = p.Y == snk.SnakeBody![0].Y && p.X == snk.SnakeBody![0].X ? Brushes.Red : Brushes.Black
            //if its starting point(head) - make it red
        };
        Canvas.SetLeft(ellipse, p.X);
        Canvas.SetTop(ellipse, p.Y);
        myCanvas.Children.Add(ellipse);
    }


    /// <summary>
    /// key down event 
    /// update direction of the snake according input
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Canvas_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
                dir = BO.Direction.Up;
                break;
            case Key.Down:
                dir = BO.Direction.Down;
                break;
            case Key.Left:
                dir = BO.Direction.Left;
                break;
            case Key.Right:
                dir = BO.Direction.Right;
                break;
        }

    }


    /// <summary>
    /// the user free the key,
    /// return direction to be null
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Canvas_KeyUp(object sender, KeyEventArgs e) => dir = null;


    /// <summary>
    /// this thread increase the speed of the 
    /// snake by 10 percent in each 5 sec
    /// </summary>
    private void SetSpeed()
    {
        while (isGameOn)
        {
            Thread.Sleep(5000);
            speed = (int)(speed * 0.9);
        }
    }


    /// <summary>
    /// this thread refresh candy list each 10 sec
    /// </summary>
    private void SetRefresh()
    {
        while (isGameOn)
        {
            cnd = bl.Candy.Refresh();
            worker.ReportProgress(0);
            Thread.Sleep(10000);
        }

    }

}

