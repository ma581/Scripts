﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;



using System.Security.Principal;
using System.Diagnostics;
using System.ComponentModel;

// Edit> Project Settings> Player > Other Settings > API Compatibility Level > Net 2.0

public class Client : MonoBehaviour
{
    private NamedPipeClientStream PipelineStream = null;
    BinaryReader br= null;
    byte[] buffer = new byte[60*22];
    string chunk;
    //public Text pipeData;
    int counter = 0;
    public bool HandTracking = false;

    private void Start()
    {
        //UnityEngine.Debug.Log("Opening pipe");
        //pipeData.text = "Opening pipe";
        //OpenPipe();

        
        //string[] chunk = new string[100];

        //do
        //for (i=0; i< 5000; i++)
        //{
        //    PipelineStream.Read(buffer, 0, buffer.Length);

        //    //chunk[i] = Encoding.ASCII.GetString(buffer);
        //    chunk = Encoding.ASCII.GetString(buffer);
        //    //foreach (var item in chunk)
        //    //{
        //    //    UnityEngine.Debug.Log(String.Format("Recieved: {0}", item));
        //    //}
        //    //UnityEngine.Debug.Log(String.Format("Recieved: {0}", chunk[i]));
        //    UnityEngine.Debug.Log(String.Format("Recieved: {0}", chunk));

        //    i++;
        //    //ClosePipe();
        //    //UnityEngine.Debug.Log("Client closed");
        //}
        //while (PipelineStream.IsConnected);
        //while (!PipelineStream.IsMessageComplete && i<chunk.Length);

        //OnDestroy();

        ////WriteAsync();
        //for  (int i = 0; i<10; i++)
        //{
        //    ReadAsync(br);
        //}
        ////ReadAsync(br);
    }

    private void Update()
    {

       // Go to Edit->Project Settings->Player, and tick "Run In Background".


        if (HandTracking)
        {

            if (PipelineStream.IsConnected)
            {
                PipelineStream.Read(buffer, 0, buffer.Length);

                chunk = Encoding.ASCII.GetString(buffer);

                //UnityEngine.Debug.Log(String.Format("Recieved ({0}) : {1}", counter, chunk));
            }
            else
            {
                OnDestroy();
            }
        }
        
        

        counter++;
    }

    private void OnDestroy()
    {
        ClosePipe();
    }

    private void OpenPipe()
    {
        //PipelineStream = new NamedPipeClientStream(".", "Pipeline", PipeDirection.In, PipeOptions.Asynchronous);

        PipelineStream = new NamedPipeClientStream("UnityPipe");
        UnityEngine.Debug.Log("Created NamedPipeClientStream");
        br = new BinaryReader(PipelineStream);

        //try
        //{
        UnityEngine.Debug.Log("Connecting pipe");
        PipelineStream.Connect();
       // }

        //catch (Win32Exception w)
        //{
        //    UnityEngine.Debug.Log(w.Message);
        //    UnityEngine.Debug.Log(w.ErrorCode.ToString());
        //    UnityEngine.Debug.Log(w.NativeErrorCode.ToString());
        //    UnityEngine.Debug.Log(w.StackTrace);
        //    UnityEngine.Debug.Log(w.Source);
        //    Exception e = w.GetBaseException();
        //    UnityEngine.Debug.Log(e.Message);
        //}

        
    }

    private void ClosePipe()
    {
        if (PipelineStream != null)
        {
            PipelineStream.Close();
            PipelineStream.Dispose();
            PipelineStream = null;
        }
    }

    private void ReadAsync(BinaryReader br)
    {
        if (PipelineStream != null && PipelineStream.IsConnected)
        {
            UnityEngine.Debug.Log("Reading Pipe data");
            //byte[] buffer = new byte[1];
            //PipelineStream.BeginRead(buffer, 0, 1, ReadAsyncCallback, null);

            //var br = new BinaryReader(PipelineStream);
            var len = (int)br.ReadUInt32();            // Read string length
            var str = new string(br.ReadChars(len));
            UnityEngine.Debug.Log(String.Format("Read: {0}", str));
        }
    }

    private void ReadAsyncCallback(IAsyncResult result)
    {
        int amountRead = PipelineStream.EndRead(result);

        if (amountRead > 0)
            ReadAsync(br);
    }

    private void WriteAsync()
    {
        //StreamWriter writer = new StreamWriter(PipelineStream);
        //writer.WriteLine("Hello");
        //writer.Flush();
    }

    public void OnClick1()
    {
        UnityEngine.Debug.Log("Opening pipe");
        OpenPipe();
    }

    public void OnClick2()
    {
        HandTracking = !HandTracking;
    }
}
