using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportPlugin
{
    public class ErrorWriteStorage : Exception
    {
        public ErrorWriteStorage(String Cause, String Message)
        {
            m_cause = Cause;
            m_message = Message;
        }

        public String GetCause()
        {
            return m_cause;
        }

        public void SetCause(String Cause)
        {
            m_cause = Cause;
        }

        public String GetMessage()
        {
            return m_message;
        }

        public void SetMessage(String Message)
        {
            m_message = Message;
        }

        public override String ToString()
        {
            String loc_message = "Error: ErrorWriteStorage...\n";
            loc_message += "Error cause: " + m_cause + '\n';
            loc_message += "Error message: " + m_message + '\n';
            return loc_message;
        }

        private String m_cause = "";
        private String m_message = "";
    }
}
