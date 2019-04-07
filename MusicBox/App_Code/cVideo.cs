using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using QuartzTypeLib;


public class cVideo
{
    private const int WM_APP = 0x8000;
    public int WM_GRAPHNOTIFY = WM_APP + 1;
    public int EC_COMPLETE = 0x01;
    public int WS_CHILD = 0x40000000;
    public int WS_CLIPCHILDREN = 0x2000000;

    public FilgraphManager m_objFilterGraph = null;
    public IBasicAudio m_objBasicAudio = null ;
    public IVideoWindow m_objVideoWindow = null ;
    public IMediaEvent m_objMediaEvent = null;
    public IMediaEventEx m_objMediaEventEx = null ;
    public IMediaPosition m_objMediaPosition = null;
    public IMediaControl m_objMediaControl = null;

    public int panelOrigTop, panelOrigLeft, panelOrigWidth, panelOrigHeight;

    enum MediaStatus { None, Stopped, Paused, Running };

    public void PlayMovie(Form F,  Panel panel, string FileName, ref int RC, ref string ErrMsg)
    {
        RC = 1; 
        Single H = 0, W = 0;

        m_objFilterGraph = new FilgraphManager();
        m_objFilterGraph.RenderFile(FileName);
        m_objBasicAudio = m_objFilterGraph as IBasicAudio;
        try
        {
            m_objVideoWindow = m_objFilterGraph as IVideoWindow;
            m_objVideoWindow.Owner = (int)panel.Handle;
            m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
            ObjectFitting(true, ref W, ref H, panelOrigWidth, panelOrigHeight, m_objVideoWindow.Width, m_objVideoWindow.Height);
            panel.Top = panelOrigTop + (panelOrigHeight - (int)H) / 2;
            panel.Left = panelOrigLeft + (panelOrigWidth - (int)W) / 2;
            panel.Width = (int)W; panel.Height = (int)H;
            m_objVideoWindow.SetWindowPosition(panel.ClientRectangle.Left,
                panel.ClientRectangle.Top,
                panel.ClientRectangle.Width,
                panel.ClientRectangle.Height);
        }
        catch (Exception e)
        {
            m_objVideoWindow = null;
            RC = 1;
            ErrMsg = "Unexpedted Error: " + e.Message;
        }

        m_objMediaEvent = m_objFilterGraph as IMediaEvent;
        m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
        m_objMediaEventEx.SetNotifyWindow((int) F.Handle, WM_GRAPHNOTIFY, 0);
        m_objMediaPosition = m_objFilterGraph as IMediaPosition;
        m_objMediaControl = m_objFilterGraph as IMediaControl;
        m_objMediaControl.Run();
    }

    public void Init(PictureBox pictureBox1, ref Panel panel1)
    {
        panel1.Top = pictureBox1.Top;
        panel1.Left = pictureBox1.Left;
        panel1.Width = pictureBox1.Width;
        panel1.Height = pictureBox1.Height;
        panelOrigLeft = panel1.Left;
        panelOrigTop = panel1.Top;
        panelOrigWidth = panel1.Width;
        panelOrigHeight = panel1.Height;
    }


    public double Duration()
    {
        m_objMediaPosition = m_objFilterGraph as IMediaPosition;
        return m_objMediaPosition.Duration;
    }

    public double CurrentPosition()
    {
        m_objMediaPosition = m_objFilterGraph as IMediaPosition;
        return m_objMediaPosition.CurrentPosition;
    }


    public Boolean IsStop()
    {
        m_objMediaPosition = m_objFilterGraph as IMediaPosition;
        if (m_objMediaPosition.CurrentPosition >= m_objMediaPosition.Duration)
            return true;
        else
            return false;
    }

    public Boolean IsPlaying()
    {
        if (m_objMediaPosition.CurrentPosition < m_objMediaPosition.Duration)
            return true;
        else
            return false;
    }

    public void Stop()
    {
        m_objMediaControl.Stop();
    }

    public void Pause()
    {
        m_objMediaControl.Pause();
    }

    public void Play()
    {
        m_objMediaControl.Run();
    }

    public void CleanUp()
    {
        if (m_objMediaControl != null)
            m_objMediaControl.Stop();

        if (m_objMediaEventEx != null)
            m_objMediaEventEx.SetNotifyWindow(0, 0, 0);

        if (m_objVideoWindow != null)
        {
            m_objVideoWindow.Visible = 0;
            m_objVideoWindow.Owner = 0;
        }

        if (m_objMediaControl != null) m_objMediaControl = null;
        if (m_objMediaPosition != null) m_objMediaPosition = null;
        if (m_objMediaEventEx != null) m_objMediaEventEx = null;
        if (m_objMediaEvent != null) m_objMediaEvent = null;
        if (m_objVideoWindow != null) m_objVideoWindow = null;
        if (m_objBasicAudio != null) m_objBasicAudio = null;
        if (m_objFilterGraph != null) m_objFilterGraph = null;
    }

    public void ObjectFitting(Boolean fFitWholePanel, ref Single retW, ref Single retH,
                              Single targetW, Single targetH, Single objW, Single objH)
    {
        Single HWRatio;
        retW = targetW;
        retH = targetH;
        if (fFitWholePanel || objH > 0 && (objH > targetH || objW > targetW))
        {
            HWRatio = objH / objW;
            if (objW > targetH)
            {
                retH = targetH;
                retW = (Single)Math.Round(targetH / HWRatio, 2);
                if (retW >= targetW)
                {
                    retW = targetW;
                    retH = (Single)Math.Round(targetW * HWRatio, 2);
                    if (retH > targetH)
                    {
                        retH = targetH;
                        retW = (Single)Math.Round(targetH / HWRatio, 2);
                    }
                }
            }
            else
            {
                retW = targetW;
                retH = (Single)Math.Round(targetW * HWRatio, 2);
                if (retH > targetH)
                {
                    retH = targetH;
                    retW = (Single)Math.Round(targetH / HWRatio, 2);
                    if (retW > targetW)
                    {
                        retW = targetW;
                        retH = (Single)Math.Round(targetW * HWRatio, 2);
                    }
                }
            }
        }
        else
        {
            retW = objW;
            retH = objH;
        }
    }

    public string Right2(string S, int N)
    {
        string R;
        if (S.Length < N)
            R = S;
        else
            R = S.Substring(S.Length - N);
        return R;
    }
    public string Left2(string S, int N)
    {
        string L;
        if (S.Length < N)
            L = S;
        else
            L = S.Substring(0, N);
        return L;
    }


}

