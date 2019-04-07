using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

class cMP3Player
{
    StringBuilder buffer = new StringBuilder(128);
    string CommandString, TempFile;
    [DllImport("winmm.dll")]
    private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

    public Boolean LoadFile(string pFileName)
    {
        try
        {
            CommandString = "close Mp3File";
            mciSendString(CommandString, null, 0, 0);
            TempFile = "Temp.mp3";
            if (File.Exists(TempFile)) File.Delete(TempFile);
            File.Copy(pFileName, TempFile);
            CommandString = "open " + "\"" + TempFile + "\"" + " type MPEGVideo alias Mp3File";
            mciSendString(CommandString, null, 0, 0);
            return true;
        }
        catch (Exception e )
        {
            string ErrMsg = e.Message;
            return false;
        }
    }

    public void Play()
    {
        CommandString = "play Mp3File";
        mciSendString(CommandString, null, 0, 0);
    }

    public void Pause()
    {
        CommandString = "pause mp3file";
        mciSendString(CommandString, null, 0, 0);
    }

    public void Stop()
    {
        CommandString = "stop Mp3File";
        mciSendString(CommandString, null, 0, 0);
    }

    public void Close()
    {
        CommandString = "close Mp3File";
        mciSendString(CommandString, null, 0, 0);
    }

    public StringBuilder Status() //audio position
    {
        CommandString = "Status Mp3File position";
        mciSendString(CommandString, buffer, 128, 0);
        return buffer;
    }


}

