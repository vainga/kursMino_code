﻿using KursCode.MVVM.View.UserControls;
using KursCode.MVVM.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KursCode.MVVM.View.Windows.Dialog
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {

        //private addWorkerViewModel viewModel;
        //private int _UserId { get; }
        
        //public AddWorker(int userId)
        //{
        //    InitializeComponent();
        //    userInputValues = new List<string>();
        //    textBoxList = new List<TextBox>();
        //    viewModel = new addWorkerViewModel();
        //    DataContext = viewModel;
        //    _UserId = userId;

        //    viewModel.UserId = _UserId;
        //    viewModel.SaveSuccessful += ViewModel_SaveSuccessful;
        //}



        //private List<ClientSkiil> userControls = new List<ClientSkiil>();

        //private void drugWindow_LeftButtonDrag(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.ButtonState == MouseButtonState.Pressed)
        //    {
        //        DragMove();
        //    }
        //}

        //private void closeApp_MauseLeftButtonDrag(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        Close();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void addQualityButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ClientSkiil userControl = new ClientSkiil();
        //    userControl.VerticalAlignment = VerticalAlignment.Top;
        //    userControl.Margin = new Thickness(10, 15, 0, 0);
        //    QualitiesWrapPanel.Children.Insert(QualitiesWrapPanel.Children.Count - 1, userControl);

        //    double totalWidth = 0;
        //    foreach (UIElement element in QualitiesWrapPanel.Children)
        //    {
        //        totalWidth += (element as FrameworkElement)?.ActualWidth ?? 0;
        //    }

        //    (QualitiesWrapPanel.Children[QualitiesWrapPanel.Children.Count - 1] as Button)?.SetValue(Canvas.LeftProperty, totalWidth);
        //    if(DataContext is addWorkerViewModel viewModel)
        //    {
        //        viewModel.TextBoxListQualities.Add(userControl.itemText);
        //    }
        //}


        //private List<string> userInputValues;
        //private List<TextBox> textBoxList;
        //private void addSkillButton_Click(object sender, RoutedEventArgs e)
        //{


        //    ClientSkiil userControl = new ClientSkiil();
        //    userControl.VerticalAlignment = VerticalAlignment.Top;
        //    userControl.Margin = new Thickness(10, 15, 0, 0);
        //    SkillsWrapPanel.Children.Insert(SkillsWrapPanel.Children.Count - 1, userControl);
        //    double totalWidth = 0;
        //    foreach (UIElement element in SkillsWrapPanel.Children)
        //    {
        //        totalWidth += (element as FrameworkElement)?.ActualWidth ?? 0;
        //    }

        //    (SkillsWrapPanel.Children[SkillsWrapPanel.Children.Count - 1] as Button)?.SetValue(Canvas.LeftProperty, totalWidth);
        //    if (DataContext is addWorkerViewModel viewModel)
        //    {
        //        viewModel.TextBoxListSkills.Add(userControl.itemText);
        //    }
        
        //}

        //private void ImageBorder_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        //{
        //    if (DataContext is addWorkerViewModel viewModel)
        //    {
        //        viewModel.SelectImage();
        //    }
        //}



        //private void ViewModel_SaveSuccessful(object sender, EventArgs e)
        //{
        //    Close();
        //}

        //private void last_button_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
