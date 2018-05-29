using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TdeA.Automata
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel()
        {
            Estados = new ObservableCollection<Estado>();
            TipoSalidas = new List<TipoSalida>
            {
                new TipoSalida{Id=1, Descripcion="Acepta" },
                new TipoSalida{Id=0, Descripcion="Rechaza" }
            };
            Limpiar();
        }
        private ObservableCollection<Estado> _Estados;
        public ObservableCollection<Estado> Estados
        {
            get { return _Estados; }
            set { _Estados = value; }
        }
        private ObservableCollection<Estado> _EstadosFinal;
        public ObservableCollection<Estado> EstadosFinal
        {
            get { return _EstadosFinal; }
            set { _EstadosFinal = value; }
        }
        public List<TipoSalida> TipoSalidas { get; set; }
        private int _CantidadEstados;
        public int CantidadEstados
        {
            get { return _CantidadEstados; }
            set { _CantidadEstados = value; OnPropertyChanged("CantidadEstados"); }
        }
        private bool _TablaHabilitada;
        public bool TablaHabilitada
        {
            get { return _TablaHabilitada; }
            set { _TablaHabilitada = value; OnPropertyChanged("TablaHabilitada"); }
        }
        private bool _CantidadHabilitada;
        public bool CantidadHabilitada
        {
            get { return _CantidadHabilitada; }
            set { _CantidadHabilitada = value; OnPropertyChanged("CantidadHabilitada"); }
        }

        #region Commands
        public ICommand LimpiarCommand
        {
            get { return new RelayCommand(Limpiar, null); }
        }
        public ICommand CrearCommand
        {
            get { return new RelayCommand(Crear, null); }
        }
        public ICommand ConvertirCommand
        {
            get { return new RelayCommand(Convertir, null); }
        }
        #endregion
        public void Limpiar()
        {
            CantidadHabilitada = true;
            TablaHabilitada = false;
            CantidadEstados = 1;
            Estados.Clear();
        }
        private void Convertir()
        {

        }
        private void Crear()
        {
            if (CantidadEstados <= 0)
            {
                MessageBox.Show("La cantidad de estados debe ser minimo 1");
                return;
            }
            CantidadHabilitada = false;
            TablaHabilitada = true;
            for (int i = 1; i <= CantidadEstados; i++)
            {
                this.Estados.Add(new Estado
                {
                    Numero = i,
                    Nombre = $"S{i}"
                });
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public class Estado
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public int Salida { get; set; }

        public string Transicion0 { get; set; }
        public string Transicion1 { get; set; }
    }
    public class TipoSalida
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

}
