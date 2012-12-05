using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace picard_bManageHospital.DataAccess
{
    class Patient
    {
        public List<Model.Patient> GetListPatient()
        {
            List<Model.Patient> listPatient = new List<Model.Patient>();
            try
            {
                ServicePatient.Patient[] serviceListPatient = new ServicePatient.ServicePatientClient().GetListPatient();
                foreach (ServicePatient.Patient servicePatient in serviceListPatient)
                {
                    Debug.WriteLine(servicePatient.Name);
                    Model.Patient p = (Model.Patient)servicePatient;
                    listPatient.Add(p);
                }
                
            }
            catch (Exception ex)
            {
                //traitement exception ...
                Debug.WriteLine(ex.Message);
            }
            return listPatient;
        }
    }
}
