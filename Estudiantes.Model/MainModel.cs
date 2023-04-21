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
        
        public PersonServiceClient cliente;

        public MainModel() 
        {
            cliente = new PersonServiceClient();

            //cliente.Open();
        }
        

        public List<Person> getPersonList()
        {
            
                return cliente.GetPeople().ToList();
            
        }

        public Person getTxtBxData(string TxtBxId, string TxtBxNombre, string TxtBxEdad, string TxtBxEmail)
        {
            var nombre = TxtBxNombre.Split(' ');
            Person nuevaPersona = new Person();

            nuevaPersona.Id = Int32.Parse(TxtBxId);
            nuevaPersona.Name = nombre[0];
            nuevaPersona.LastName = nombre[1];
            nuevaPersona.Age = Int32.Parse(TxtBxEdad);
            nuevaPersona.Email = TxtBxEmail;
            //Obtengo los datos actualizados o nuevos de los cuadros de texto.
            return nuevaPersona;
        }        

        public void saveEstudiante(int indexFilaSelect, Person person, bool isValidFields)
        {
            //Se hizo de esta manera, adaptándolo como en la versión de consola
            //claramente, se puede editar la función AddPerson
            //para aceptar solo un Person
            //pero a fines prácticos, se dejó tal cual.
            Person[] people = new Person[1];
            people[people.Length - 1] = person;
            
                if (indexFilaSelect > -1 && isValidFields)
                {
                    //Actualiza un nuevo estudiante.
                    cliente.UpdatePerson(people[0]);
                    
                }
                else if (isValidFields)
                {
                    //Crea un nuevo estudiante.
                    cliente.AddPerson(people);
                }
            
            
        }

        public void removeEstudiante(int indexFilaEliminate, Person person)
        {
            
                if (indexFilaEliminate > -1)
                {
                    cliente.DeletePerson(person.Id);

                    //updateFormComponents();
                }
                else
                {
                    //MessageBox.Show("Seleccione un elemento para eliminar. :)");
                }
            
            
        }
    }

    
}
