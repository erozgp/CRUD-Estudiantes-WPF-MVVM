using Estudiantes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Estudiantes.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private MainModel model;

        private int indexFilaSelect = -1;
        private string txtBxNombre;
        private string txtBxEdad;
        private string txtBxEmail;
        private List<Estudiante> estudiantesList;
        private Object estudianteData;

        public int IndexFilaSelect
        {
            get { return indexFilaSelect; }

            set
            {
                if (indexFilaSelect == value)
                {
                    return;
                }
                indexFilaSelect = value;
                OnPropertyChanged("IndexFilaSelect");
            }
        }

        public string TxtBxNombre
        {
            get { return txtBxNombre; }

            set
            {
                if (txtBxNombre == value)
                {
                    return;
                }
                txtBxNombre = value;
                OnPropertyChanged("TxtBxNombre");
            }
        }

        public string TxtBxEdad
        {
            get { return txtBxEdad; }

            set
            {
                if (txtBxEdad == value)
                {
                    return;
                }
                txtBxEdad = value;
                OnPropertyChanged("TxtBxEdad");
            }
        }

        public string TxtBxEmail
        {
            get { return txtBxEmail; }

            set
            {
                if (txtBxEmail == value)
                {
                    return;
                }
                txtBxEmail = value;
                OnPropertyChanged("TxtBxEmail");
            }
        }

        public List<Estudiante> EstudiantesList
        {
            get { return estudiantesList; }

            set
            {
                if (estudiantesList == value)
                {
                    return;
                }
                estudiantesList = value;
                OnPropertyChanged("EstudiantesList");
            }
        }

        public Object EstudianteData
        {
            get { return estudianteData; }

            set
            {
                if (estudianteData == value)
                {
                    return;
                }
                estudianteData = value;
                setFormDataEstudiante((Estudiante)estudianteData);
                OnPropertyChanged("EstudianteData");
            }
        }

        //Comandos para ejecución de funciones dentro del MainModel
        private ICommand removeCommand;
        private ICommand addCommand;

        private void setFormDataEstudiante(Estudiante estudianteData)
        {
            if (estudianteData != null)
            {
                TxtBxNombre = estudianteData.Nombre;
                TxtBxEdad = Convert.ToString(estudianteData.Edad);
                TxtBxEmail = estudianteData.Email;
            }
            else
            {
                updateFormComponents();
            }
        }

        private void updateFormComponents()
        {
            //Actualizo el DataGridView y valores.
            TxtBxNombre = null;
            TxtBxEdad = null;
            TxtBxEmail = null;
            indexFilaSelect = -1;
            //indexFilaEliminate = -1;
            EstudiantesList = null;
            EstudiantesList = model.getEstudianteList();
        }

        private Estudiante formatEstudiante()
        {
            return model.getTxtBxData(TxtBxNombre, TxtBxEdad, TxtBxEmail);
        }

        private Boolean isFieldNotNullValidator()
        {
            //Se valida el contenido en las cajas de texto.
            if (!string.IsNullOrEmpty(TxtBxNombre) && !string.IsNullOrEmpty(TxtBxEdad) && !string.IsNullOrEmpty(TxtBxEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    removeCommand = new RelayCommand(param => this.removeCommandExecute(), null);
                }
                return removeCommand;
            }

        }

        public ICommand AddCommand 
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(param => this.addCommandExecute(), null);
                }
                return addCommand;
            }

        }

        private void addCommandExecute()
        {
            model.saveEstudiante(IndexFilaSelect, formatEstudiante(), isFieldNotNullValidator());
            updateFormComponents();
        }

        private void removeCommandExecute()
        {
            model.removeEstudiante(IndexFilaSelect);
            updateFormComponents();
        }

        public MainViewModel()
        {
            model = new MainModel();
            model.saveEstudiante(new Estudiante("Erick", 23, "erozgp@gmail.com"));
            EstudiantesList = model.getEstudianteList();
        }
    }

}
