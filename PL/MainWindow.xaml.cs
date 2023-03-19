using BLimplementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    Image myImg = new();

    BO.Snake snk;

    BO.Candy cnd;

    BlApi.IBL bl = new BLimplementation.BL();

    BackgroundWorker worker = new();

    Thread handleSpeed;
    
    int speed = 100;
    
    BO.Direction? dir;

    public MainWindow()
    {
        InitializeComponent();

        snk = bl.Snake.Read();
        cnd = bl.Candy.Read();
        myImg.Source = new BitmapImage(new Uri("C:\\Users\\ohevd\\source\\repos\\Snake\\PL\\Image\\dollar.png"));
        handleSpeed = new(SetSpeed);

        BLimplementation.Snake.CandyEatenEvent += Snake_CandyEatenEvent;
        worker.DoWork += Worker_DoWork;
        worker.ProgressChanged += Worker_ProgressChanged;
        worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

        worker.WorkerReportsProgress = true;
        worker.WorkerSupportsCancellation = true;
        
        handleSpeed.Start();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        myCanvas.Children.RemoveAt(0);

        //Initialize snake body on screen 
        foreach (var p in snk.SnakeBody!)
            CreateEllipse(p);


        //initialize candys on screen
        foreach (var c in cnd.CandysOnMap!)
            CreateImage(c);

        worker.RunWorkerAsync();
    }

    private void Worker_DoWork(object? sender, DoWorkEventArgs e)
    {
        while (true)
        {
            if (bl.Snake.IsGameOn())
            {
                snk = bl.Snake.UpdateMove(dir);
                worker.ReportProgress(1);
                Thread.Sleep(speed);
            }
            else
            {
                MessageBox.Show("Game Over", "Your Snake Is Dead", MessageBoxButton.OK, MessageBoxImage.Exclamation
                , MessageBoxResult.OK);

                worker.CancelAsync();
            }
        }
    }

    private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)//screen update
    {
        if (e.ProgressPercentage == 1)
            UpdateSnakeOnScreen();
        else
            UpdateCandyesOnScreen();
    }
    private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        worker.DoWork -= Worker_DoWork;
        worker.ProgressChanged -= Worker_ProgressChanged;
        worker.RunWorkerCompleted -= Worker_RunWorkerCompleted;
        BLimplementation.Snake.CandyEatenEvent -= Snake_CandyEatenEvent;
        this.Close();
    }

    private void Snake_CandyEatenEvent()
    {
        cnd = bl.Candy.Read();
        worker.ReportProgress(0);
    }

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

    private void CreateImage(BO.Point candy)
    {
        Image img = new()
        {
            Source = myImg.Source,
            Height = 10,
            Width = 10,
            
        };
        Canvas.SetLeft(img, candy.X);
        Canvas.SetTop(img, candy.Y);
        myCanvas.Children.Add(img);
    }

    private void CreateEllipse(BO.Point p)
    {
        Ellipse ellipse = new()
        {
            Width = 10,
            Height = 10,
            Fill = p.X ==300 && p.Y == 200 ? Brushes.Red  : Brushes.Black//if its starting point - head - make it red
        };
        Canvas.SetLeft(ellipse, p.X);
        Canvas.SetTop(ellipse, p.Y);
        myCanvas.Children.Add(ellipse);
    }

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

    private void Canvas_KeyUp(object sender, KeyEventArgs e) => dir = null;

    private void SetSpeed()
    {
        while (true)
        {
            Thread.Sleep(5000);
            speed = (int)(speed * 0.9);
        }
    }

 
}

