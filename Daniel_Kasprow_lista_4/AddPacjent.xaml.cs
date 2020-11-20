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
using System.IO;
using Microsoft.Win32;

namespace Daniel_Kasprow_lista_4
{
    /// <summary>
    /// Interaction logic for AddPacjent.xaml
    /// </summary>
    public partial class AddPacjent : Window
    {
        Pacjent kln;

        MainWindow mainwindow;

        string picture = "C:\\Users\\Daniel\\Desktop\\pliki\\Różne\\MINECRAFT\\maxresdefault.jpg";
        Uri uri;
        public AddPacjent()
        {
            InitializeComponent();
        }

        public AddPacjent(MainWindow mainwindow) : this()
        {
            this.mainwindow = mainwindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                {
                    openFileDialog.Title = "Select picture of patient";
                    openFileDialog.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                    openFileDialog.Multiselect = false;
                }
                if (openFileDialog.ShowDialog() == true)
                {
                    picture = openFileDialog.FileName;
                    uri = new Uri(picture, UriKind.Absolute);
                }
                if (Convert.ToInt64(TextPesel.Text) > 9999999999 && Convert.ToInt64(TextPesel.Text) <= 99999999999)
                {
                    kln = new Pacjent(TextImie.Text, TextNazwisko.Text,TextUlica.Text,TextUlica.Text,TextKraj.Text,Convert.ToInt32(TextNr.Text),Convert.ToInt32(TextWiek.Text), Convert.ToInt64(TextPesel.Text),picture);
                    MainWindow.klient.Add(kln);
                    this.Hide();
                }
                else MessageBox.Show("zla dlugosc pesela");
            }
            catch
            {
                MessageBox.Show("nr ulicy,wiek i pesel musi byc liczba");
            }
        }

    }
 }

