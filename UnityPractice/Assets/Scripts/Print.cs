﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    public GameObject runner;
    public GameObject bee;
    public string output = "";

    public string fileName = "test";
    public Transform[] dataObj;

 

    //Static Declarations
    public static string folder;
    public static string dataFile;
    public static string cfgFile;

    //Counters/Classifiers
    public static int trialNum = 0;
    public string[] ID = null;
    private StringBuilder line; //current line to write

    //Constants
    private string del = ","; //delimiter for writing csv files (next column)
    private string nwl = System.Environment.NewLine; //new line for writing csv files (next row)
    private StreamWriter writer; //StreamWriter for data file


    //////////////////////////////////////////////////////////////////

    //Initialization function
    void Start() //is this initialization? if so, make files
    {

        int n = 0;
        fileName = fileName + '_';

        //check for existence of filename, add iteration at end of name if exists
        while (Directory.Exists(Application.dataPath + "/data/" + fileName + n) == true)
        {
            n++;
        }
        fileName = fileName + n;

        //Create folder and files for current subject
        folder = Application.dataPath + "/data/" + fileName;
        dataFile = folder + "/data.csv";
        cfgFile = folder + "/cfg.csv";

        Directory.CreateDirectory(folder);

        output = "";
        using (writer = new StreamWriter(dataFile, true))
        {
           

            output += "Time" + del;
            output += "FPS" + del;

            for (int ii = 0; ii < dataObj.Count(); ii++)
            {
                output += dataObj[ii].name + "PosX" + del;
                output += dataObj[ii].name + "PosY" + del;
                output += dataObj[ii].name + "PosZ" + del;
                output += dataObj[ii].name + "RotX" + del;
                output += dataObj[ii].name + "RotY" + del;
                output += dataObj[ii].name + "RotZ" + del;
            }

            writer.WriteLine(output);
            writer.Close();
        }
    }



        // Update is called once per frame
        void Update()
        {
               output = "";
                using (writer = new StreamWriter(dataFile, true))
                {
                    output += Time.time + del;
                    output += (1 / Time.deltaTime) + del;

                    for (int ii = 0; ii < dataObj.Count(); ii++)
                    {
                        output += dataObj[ii].position.x + del;
                        output += dataObj[ii].position.y + del;
                        output += dataObj[ii].position.z + del;
                        output += dataObj[ii].rotation.x + del;
                        output += dataObj[ii].rotation.y + del;
                        output += dataObj[ii].rotation.z + del;
                    }

                    writer.WriteLine(output);
                    writer.Close();
                }
        }

    
}
