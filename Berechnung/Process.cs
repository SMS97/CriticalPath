using System;
using System.Collections.Generic;
using System.Text;

namespace Berechnung
{
    public class Process
    {
        public int faz = -1;
        public int fez = -1;
        public int saz = -1;
        public int sez = -1;
        public List<Process> preProcesses = new List<Process>();
        public List<Process> succProcesses = new List<Process>();
        public Process(int id, string name, int dauer)
        {
            ID = id;
            Name = name;
            Dauer = dauer;
        }
        public void AddPredecessor(Process preProcess)
        {
            preProcesses.Add(preProcess);
            preProcess.AddSaveSuccessor(this);
        }
        public void AddSuccessor(Process succProcess)
        { 
            succProcesses.Add(succProcess);
            succProcess.AddSavePredecessor(this);
        }
        public bool isPredecessor(Process process)
        {
            if(preProcesses.Contains(process))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isSuccessor(Process process)
        {
            if(succProcesses.Contains(process))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddSaveSuccessor(Process process)
        {
            bool isPreProcess = isPredecessor(process);
            if(isPreProcess)
            {
                //ignore
            }
            else
            {
                succProcesses.Add(process);
            }
        }
        public void AddSavePredecessor(Process process)
        {
            bool isSuccProcess =  isSuccessor(process);
            if(isSuccProcess)
            {
                //ignore
            }
            else
            {
                preProcesses.Add(process);
            }
        }
        public bool isStartProcess()
        {
            if(preProcesses.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEndProcess()
        {
            if (succProcesses.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void calcFAZ()
        {
            if(isStartProcess())
            {
                faz = 0;
                fez = faz + Dauer;
            }
            else
            {
                int nextFaz = 0;
                foreach(Process process in preProcesses)
                {
                    process.calcFAZ();
                    if(process.fez != -1 && process.fez >= nextFaz)
                    {
                        nextFaz = process.fez;
                    }
                }
                faz = nextFaz;
                fez = faz + Dauer;
                
            }
        }
        public bool isCritcal()
        {
            calcSEZ();
            if(faz == saz)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void calcSEZ()
        {
            if(faz == -1)
            {
                calcFAZ();
            }
            if(isEndProcess())
            {
                sez = fez;
                saz = sez - Dauer;
            }
            else
            {
                int nextSez = 32000;
                foreach(Process process in succProcesses)
                {
                    process.calcSEZ();
                    if(process.saz != -1 && process.saz <= nextSez)
                    {
                        nextSez = process.saz;
                    }
                }
                sez = nextSez;
                saz = sez - Dauer;
            }
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Dauer { get; set; }
    }
}
