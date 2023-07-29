using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using PhoneApp.Plugin;
using PhoneApp.Domain;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System.Security;

namespace ExportPlugin
{
    public class ExportPlugin : IPluggable
    {
        public List<Employee> Run(List<Employee> employees)
        {
            String loc_json_text = "";
            List<EmployeesDTO>? loc_employees = new List<EmployeesDTO>();
            
            if (m_json_export_file == null || m_json_export_file == String.Empty)
            {
                String loc_message = "NAMESPACE: ExportPlugin.\n";
                loc_message += "CLASS: ExportPlugin.\n";
                loc_message += "FUNCTION: List<Employee> Run(List<Employee> args).\n";
                loc_message += "MESSAGE: Instance has not have file to export.\n";
                throw new ArgumentNullException(loc_message);
            }

            try
            {
                loc_json_text = File.ReadAllText(m_json_export_file);
            }

            catch (SecurityException e)
            {
                String loc_cause = "SecurityException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }

            catch (NotSupportedException e)
            {
                String loc_cause = "FileNotFoundException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }

            catch (FileNotFoundException e)
            {
                String loc_cause = "FileNotFoundException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }

            catch (UnauthorizedAccessException e)
            {
                String loc_cause = "UnauthorizedAccessException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }

            catch (PathTooLongException e)
            {
                String loc_cause = "PathTooLongException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }
            
            catch (DirectoryNotFoundException e)
            {
                String loc_cause = "DirectoryNotFoundException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }

            catch (IOException e)
            {
                String loc_cause = "IOException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }

            catch (ArgumentNullException e)
            {
                String loc_cause = "ArgumentNullException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }

            catch(ArgumentException e)
            {
                String loc_cause = "ArgumentException";
                String loc_message = "Error reading file " + m_json_export_file;
                throw new ErrorReadStorage(loc_cause, loc_message);
            }

            try
            {
                loc_employees = JsonSerializer.Deserialize<List<EmployeesDTO>>(loc_json_text);
            }

            catch (ArgumentNullException e)
            {
                String loc_cause = "ArgumentNullException";
                String loc_message = "Error deserialization from file " + m_json_export_file;
                throw new ErrorDeserialization(loc_cause, loc_message);
            }

            catch (JsonException e)
            {
                String loc_cause = "JsonException";
                String loc_message = "Data format error in file " + m_json_export_file;
                throw new ErrorDeserialization(loc_cause, loc_message);
            }

            catch (NotSupportedException e)
            {
                String loc_cause = "NotSupportedException";
                String loc_message = "Error in deserialization from file " + m_json_export_file;
                throw new ErrorDeserialization(loc_cause, loc_message);
            }

            foreach(var loc_curr_employee in loc_employees)
            {
                employees.Append<Employee>(loc_curr_employee);
            }

            System.Console.WriteLine("Added " + loc_employees.Count + " employees...");
            return employees;
        }


        public void SetJsonExportFileName(String ExportFileName)
        {
            if(ExportFileName == null)
            {
                String loc_message = "NAMESPACE: ExportPlugin.\n";
                loc_message += "CLASS: ExportPlugin.\n";
                loc_message += "FUNCTION: SetJsonExportFileName().\n";
                loc_message += "MESSAGE: Argument ExportFileName are null reference.\n";
                throw new ArgumentNullException(loc_message);
            }

            if (ExportFileName == String.Empty)
            {
                String loc_message = "NAMESPACE: ExportPlugin.\n";
                loc_message += "CLASS: ExportPlugin.\n";
                loc_message += "FUNCTION: SetJsonExportFileName().\n";
                loc_message += "MESSAGE: Argument ExportFileName are empty string.\n";
                throw new ArgumentException(loc_message);
            }

            if(File.Exists(ExportFileName) == false)
            {
                String loc_message = "File with name " + ExportFileName + " not found.";
                throw new FileNotFoundException(loc_message);
            }

            m_json_export_file = ExportFileName;
        }

        public String GetJsonExportFileName()
        {
            return m_json_export_file;
        }

        private String m_json_export_file = "";
    }
}