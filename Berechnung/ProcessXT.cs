using System;
using System.Collections.Generic;
using System.Text;

namespace Berechnung
{
    public class ProcessXT : Process
    {
        public bool isCriticalPath;
        public ProcessXT(int id, string name, int dauer)
            :base(id,name, dauer)
        {

        }

        public int calcGP(out ProcessXT critProcess)
        {
            int[] array = new int[succProcesses.Count];
            for(int i = 0; i < succProcesses.Count; i++)
            {
                succProcesses[i].calcSEZ();
                array[i] = succProcesses[i].saz;
            }
            int gp;
            calcFAZ();
            calcSEZ();
            if (array.Length > 0)
            {
                ArrayHandler handler = new ArrayHandler(array);
                int minVal = handler.MinValueOfArray;
                
                gp = minVal - fez;
                critProcess = (ProcessXT)succProcesses[handler.IndexOfMinValue];
            }
            else
            {
                gp = sez - fez;
                critProcess = null;
            }
            return gp;
        }
        public int calcFP()
        {
            int[] array = new int[succProcesses.Count];
            for(int i = 0; i < succProcesses.Count; i++)
            {
                succProcesses[i].calcFAZ();
                array[i] = succProcesses[i].faz;
            }
            ArrayHandler handler = new ArrayHandler(array);
            int minValue = handler.MinValueOfArray;
            calcFAZ();
            calcSEZ();
            int fp = minValue - fez;
            return fp;
        }
        public void calcCriticalPath()
        {
            int gp = calcGP(out ProcessXT critProcess);
            if(gp == 0)
            {
                isCriticalPath = true;
                if (critProcess != null)
                {
                    critProcess.calcCriticalPath();
                }
            }
            else
            {
                isCriticalPath = false;
            }
        }
        public int GP { get => calcGP(out ProcessXT process); }
        public int FP { get => calcFP(); }
    }
}
