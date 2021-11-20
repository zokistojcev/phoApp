using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace App26.Models
{
    public class Tipovi : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int PID { get; set; }
        public string IN { get; set; }
        private int _tID;
        public int TID
        {
            get { return _tID; }
            set
            {
                _tID = value;
                OnPropertyChanged("TID");
            }
        }
        public string K { get; set; }
        public DateTime DI { get; set; }
        public decimal? G { get; set; }
        public string Granica { get; set; }
        public string TP { get; set; }
        public string TIDPID { get; set; }
        public string TPGDisplay
        {

            get
            {
                if (this.TP.Contains("$"))
                {
                    string tempnew = TP.Replace("$", G.ToString());
                    return tempnew;
                }
                else
                {
                    return this.TP;
                }
            }
        }
        public int IWID { get; set; }
        public int TO { get; set; }

        private Color _buttonColor = Color.Blue;
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                OnPropertyChanged("ButtonColor");
            }
        }
        private Color _buttonTextColor = Color.White;
        public Color ButtonTextColor
        {
            get { return _buttonTextColor; }
            set
            {
                _buttonTextColor = value;
                OnPropertyChanged("ButtonTextSelectedColor");
            }
        }
        private Color _borderButtonColor = Color.Aquamarine;
        public Color BorderButtonColor
        {
            get { return _borderButtonColor; }
            set
            {
                _borderButtonColor = value;
                OnPropertyChanged("BorderButtonColor");
            }
        }
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;

                if (_isSelected == true)
                {
                    ButtonColor = Color.Yellow;
                    ButtonTextColor = Color.Orange;
                    BorderButtonColor = Color.Red;
                }
                else
                {
                    ButtonColor = Color.Blue;
                    ButtonTextColor = Color.AliceBlue;
                    BorderButtonColor = Color.Aquamarine;
                }
                OnPropertyChanged("IsSelected");
                OnPropertyChanged("ButtonTextColor");
                OnPropertyChanged("ButtonColor");
                OnPropertyChanged("BorderButtonColor");
            }
        }
        public string PercentCell { get; set; }
    }
}
