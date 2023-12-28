﻿using System;
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
    /// Логика взаимодействия для InterviewWindow.xaml
    /// </summary>
    public partial class InterviewWindow : Window
    {
        public InterviewWindow()
        {
            InitializeComponent();
        }

        private void closeApp_MauseLeftButtonDrag(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
