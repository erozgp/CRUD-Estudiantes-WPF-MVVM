using Estudiantes.Model.PersonServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Estudiantes.Model
{
    public class MainModel
    {
        /*
        ControllerCRUD controllerCRUD = new ControllerCRUD();
        //Creaci�n e inicializaci�n de la variable que almacena el �ndice para el Estudiante seleccionado.
        //int indexFilaSelect = -1;
        //int indexFilaEliminate = -1;

        public void saveEstudiante(Estudiante newDataEstudiante)
        {
            //Crea un nuevo estudiante.
            controllerCRUD.AddEstudiante(newDataEstudiante);
        }
        public void saveEstudiante(int indexFilaSelect, Estudiante newDataEstudiante, Boolean isValidFields)
        {
            if (indexFilaSelect > -1 && isValidFields)
            {
                //Actualiza un nuevo estudiante.
                controllerCRUD.UpdateEstudiante(indexFilaSelect, newDataEstudiante);
            }
            else if (isValidFields)
            {
                //Crea un nuevo estudiante.
                controllerCRUD.AddEstudiante(newDataEstudiante);
            }
            
        }

        public Estudiante getTxtBxData(string TxtBxNombre, string TxtBxEdad, string TxtBxEmail)
        {
            //Obtengo los datos actualizados o nuevos de los cuadros de texto.
            return new Estudiante(
                TxtBxNombre,
                Int32.Parse(TxtBxEdad),
                TxtBxEmail);
        }

        public List<Estudiante> getEstudianteList()
        {
            return controllerCRUD.GetEstudiantes();
        }
        public void removeEstudiante(int indexFilaEliminate)
        {
            if (indexFilaEliminate > -1)
            {
                controllerCRUD.RemoveEstudiante(indexFilaEliminate);

                //updateFormComponents();
            }
            else
            {
                //MessageBox.Show("Seleccione un elemento para eliminar. :)");
            }
        }

        */
        
        PersonServiceClient cliente;

        public MainModel() 
        {
            cliente = new PersonServiceClient();
        }
        

        public List<Person> getPersonList()
        {
            using (cliente)
            {
                return cliente.GetPeople().ToList();
            }
        }

    }

    
}
