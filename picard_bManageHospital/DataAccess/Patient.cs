using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace picard_bManageHospital.DataAccess
{
    class Patient
    {
        public List<ServicePatient.Patient> GetListPatient()
        {
            List<ServicePatient.Patient> serviceListPatient = new List<ServicePatient.Patient>();
            try
            {
                serviceListPatient = new ServicePatient.ServicePatientClient().GetListPatient().ToList();
            }
            catch (Exception ex)
            {
                //traitement exception ...
                Debug.WriteLine(ex.Message);
            }
            return serviceListPatient;
        }
    }
}
