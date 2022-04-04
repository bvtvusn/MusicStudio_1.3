using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicStudio_1._3.BLL;

namespace MusicStudio_1._3.GUI
{
    class NoteView
    {
        // Fixed Variables
        int verticalSpacing = 3;


        // Dynamic Variables
        public double view_StartTime = 0;
        public double view_centerTone = 72;
        public double horizontalZoomFactor = 80; // Pixels/time unit
        public double verticalZoomFactor = 10; // Pixels/Note


        // Calculated Variables
        int verticalCCdist;
        int verticalNoteHeight;
        double noteSpan;
        double timeSpan;
        int canvasHeight;
        int canvasWidth;


        // Mouse Related
        MouseStates mousestate = 0;
        bool mouseIsDown_left = false;
        //Point mouseDownPoint;
        double move_InitialNote;
        double move_InitialTime;
        double curMouseTime;
        double curMouseNote;
        //Point currentMousePos;
        double clickOffset_X;
        double clickOffset_Y;



        private BusinessLayer rBll;
        private Form1 form1;
        private Track track;
        enum MouseStates
        {
            None,
            HoverNote,
            HoverNoteStart,
            HoverNoteEnd,
            MovingNote,
            MovingLeftEnd,
            MovingRightEnd,
            Selecting



        }

        public NoteView(BusinessLayer rBll,Track track, Form1 form1) //
        {
            this.rBll = rBll;
            this.track = track;
            this.form1 = form1;

            Rectangle CanvasSize = new Rectangle(0, 0, 300, 200);
            CalcDrawingParameters(CanvasSize);

            double ts = NoteToPos(440);
            double sv = PosToNote(ts);

            double _ts = TimeToPos(440);
            double _sv = PosToTime(_ts);
        }

        List<NoteUnit> GetNotes()
        {
            return track.GetNotesInInterval(
            
               view_StartTime,
               view_StartTime + timeSpan,
               view_centerTone - 0.5 * noteSpan,
               view_centerTone + 0.5 * noteSpan);
        }


        public void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            PictureBox curPicBox = (sender as PictureBox);
            // -------------------- Background


            //Drawing the backgroundcolor for the drawing area
            Rectangle CanvasSize = new Rectangle(0,0,curPicBox.Width,curPicBox.Height);
            CalcDrawingParameters(CanvasSize);
            //Brush canvasBrush = new SolidBrush(Color.FromArgb(100, 100, 100, 100));
            //e.Graphics.FillRectangle(canvasBrush, CanvasSize);


            Brush NoteBrush = new SolidBrush(Color.FromArgb(255, 255, 69, 0));
            Brush NoteSelectedBrush = new SolidBrush(Color.FromArgb(255, 230, 100, 0));
            List<NoteUnit> notes = GetNotes();

            // moved since mousedown:
            int notePxChange = Convert.ToInt32(NoteToPos(curMouseNote) - NoteToPos(move_InitialNote) - clickOffset_Y);
            int timePxChange = Convert.ToInt32(TimeToPos(curMouseTime) - TimeToPos(move_InitialTime) - clickOffset_X);

            //Point posChange = Point.Subtract(currentMousePos, new Size(mouseDownPoint));
            Point posChange = new Point(timePxChange, notePxChange);
            for (int i = 0; i < notes.Count; i++)
            {
                int timePXstart = Convert.ToInt32(TimeToPos(notes[i].Start));
                int timePXend = Convert.ToInt32(TimeToPos(notes[i].Stop_));

                //double pitch = notes[i].GetNoteVal();

                //double ihu = NoteToPos(notes[i].GetNoteVal());
                //double fsf = PosToNote(ihu);
                int pitchPXlow = Convert.ToInt32(NoteToPos(notes[i].GetNoteVal() ) + verticalNoteHeight/2.0);
                int pitchPXhigh = pitchPXlow - verticalNoteHeight;
                Rectangle noteRect = new Rectangle(timePXstart, pitchPXhigh, timePXend - timePXstart, -pitchPXhigh + pitchPXlow);

                if (notes[i].selected)
                {
                    if (mousestate == MouseStates.MovingNote) {

                        double timeChange = 0, noteChange = 0;
                        GetMouseChange(ref timeChange, ref noteChange);
                        noteRect.X += Convert.ToInt32(timeChange * horizontalZoomFactor);
                        noteRect.Y += Convert.ToInt32(-noteChange * verticalZoomFactor);

                    }
                    else if (mousestate == MouseStates.MovingRightEnd)
                    {
                        double noteChange = 0, timeChange = 0;
                        GetMouseChange(ref timeChange, ref noteChange);

                        noteRect.Width += Convert.ToInt32(timeChange * horizontalZoomFactor);
                        
                    }
                    else if (mousestate == MouseStates.MovingLeftEnd)
                    {
                        double noteChange = 0, timeChange = 0;
                        GetMouseChange(ref timeChange, ref noteChange);

                        noteRect.X += Convert.ToInt32(timeChange * horizontalZoomFactor);
                        noteRect.Width -= Convert.ToInt32(timeChange * horizontalZoomFactor);

                    }
                    
                    e.Graphics.FillRectangle(NoteSelectedBrush, noteRect);
                }
                else e.Graphics.FillRectangle(NoteBrush, noteRect);


            }

            if (mousestate == MouseStates.Selecting) // Show "Select" rectangle
            {
                
                int lowTime = Convert.ToInt32(TimeToPos(Math.Min(move_InitialTime, curMouseTime)));
                int highTime = Convert.ToInt32(TimeToPos(Math.Max(move_InitialTime, curMouseTime)));
                int highNote = Convert.ToInt32(NoteToPos(Math.Min(move_InitialNote, curMouseNote)));
                int lowNote = Convert.ToInt32(NoteToPos(Math.Max(move_InitialNote, curMouseNote)));
                Rectangle selRect = new Rectangle(lowTime, lowNote, highTime - lowTime, highNote - lowNote);

                using (Brush selectBrush = new SolidBrush(Color.FromArgb(50, 125,204,255)))
                {
                    e.Graphics.FillRectangle(selectBrush, selRect);
                }
            }

        }

        public Bitmap CreateBackground(int width, int height)
        {
            //PictureBox canvas = (sender as PictureBox);
            Bitmap bmpGridlines = new Bitmap(width, height);

            using (Graphics gr = Graphics.FromImage(bmpGridlines))
            {
                using (Brush canvasBrush = new SolidBrush(Color.FromArgb(100, 100, 100, 100)))
                {
                    gr.FillRectangle(canvasBrush, 0, 0, bmpGridlines.Width, bmpGridlines.Height);
                }


                double y0 = Math.Round(PosToNote(0));
                double y1 = Math.Round(PosToNote(bmpGridlines.Height));
                double x0 = Math.Round(PosToTime(0));
                double x1 = Math.Round(PosToTime(bmpGridlines.Width));

                float y0_round = Convert.ToSingle(NoteToPos(Math.Round(y0)));
                double y1_round = NoteToPos(Math.Round(y1));
                float x0_round = Convert.ToSingle(TimeToPos(Math.Round(x0)));
                double x1_round = TimeToPos(Math.Round(x1));


                float realYspacing = Convert.ToSingle((y1_round - y0_round) / (y0 - y1));

                using (Pen curPen = new Pen(Color.FromArgb(255, 64, 64, 64), 0.01f))
                {
                    int i_y = Convert.ToInt32(y0_round); // the minimum value
                    int i_maxY = Convert.ToInt32(y1_round); // the maximum value
                    while (i_y <= i_maxY)
                    {
                        float lineHeight = Convert.ToSingle(verticalSpacing / 2 + verticalNoteHeight / 2.0 + y0_round + i_y * realYspacing);
                        gr.DrawLine(curPen, 0, lineHeight, bmpGridlines.Width, lineHeight);
                        i_y++;
                    }

                    float realXspacing = Convert.ToSingle((x1_round - x0_round) / (x1 - x0));


                    int i_x = Convert.ToInt32(y0_round); // the minimum value
                    int i_maxX = Convert.ToInt32(y1_round); // the maximum value
                    while (i_x <= i_maxX)
                    {
                        gr.DrawLine(curPen, x0_round + i_x * realXspacing, 0, x0_round + i_x * realXspacing, bmpGridlines.Height);
                        i_x++;
                    }
                }

            }

            return bmpGridlines;
            
        }

        private void CalcDrawingParameters(Rectangle canvasSize)
        {
            canvasHeight = canvasSize.Height;
            canvasWidth = canvasSize.Width;

            noteSpan = PosToNote(0) - PosToNote(canvasHeight);
            timeSpan = PosToTime(canvasWidth) - PosToTime(0);
            verticalCCdist = Convert.ToInt32(canvasHeight / noteSpan);
            verticalNoteHeight = verticalCCdist - verticalSpacing;

            
            
        }

        

        double TimeToPos(double time)
        {
            return (time - view_StartTime) * horizontalZoomFactor;
        }
        double PosToTime(double pos)
        {
            return pos / horizontalZoomFactor + view_StartTime;
        }
        double NoteToPos(double note)
        {
            return (note - view_centerTone) * -verticalZoomFactor + canvasHeight/2;
        }
        double PosToNote(double pos)
        {
           return (pos - canvasHeight / 2) / -verticalZoomFactor + view_centerTone;
        }

        public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            curMouseTime = PosToTime(e.X);
            curMouseNote = PosToNote(e.Y);
            //currentMousePos = e.Location;
            if (mouseIsDown_left == false)
            {
                
                //Note curNote = rBll.GetNoteAt(curMouseTime, curMouseNote);
                NoteUnit curNote = track.GetNoteAt(curMouseTime, curMouseNote);
                if (curNote != null) // Hovering over note!
                {
                
                    double startPixel = TimeToPos(curNote.Start);
                    double stopPixel = TimeToPos(curNote.Stop_);
                    if (e.X <= startPixel + 5) // left Edge
                    {
                    
                        mousestate = MouseStates.HoverNoteStart;
                    }
                    else if(e.X >= stopPixel - 5) // Right Edge
                    { 
                        mousestate = MouseStates.HoverNoteEnd;
                    }
                    else // Over note center
                    { 
                        mousestate = MouseStates.HoverNote;
                    }
                }
                else
                {
                    mousestate = MouseStates.None;
                }
            }
            else // MouseIsDown == true
            {
                NoteUnit curNote = new NoteUnit();
                if (mousestate == MouseStates.HoverNote || mousestate == MouseStates.HoverNoteStart || mousestate == MouseStates.HoverNoteEnd)
                {
                    curNote = track.GetNoteAt(move_InitialTime, move_InitialNote);
                }
                switch (mousestate)
                {
                    case MouseStates.None:
                        mousestate = MouseStates.Selecting;
                        break;
                    case MouseStates.HoverNote:
                        mousestate = MouseStates.MovingNote;

                        clickOffset_X = (move_InitialTime - curNote.Start) * horizontalZoomFactor;
                        clickOffset_Y = (- move_InitialNote + curNote.NoteVal) * verticalZoomFactor;

                        move_InitialNote = curNote.NoteVal;
                        move_InitialTime = curNote.Start;

                        
                        
                        break;
                    case MouseStates.HoverNoteStart:
                        mousestate = MouseStates.MovingLeftEnd;

                        clickOffset_X = (move_InitialTime - curNote.Start) * horizontalZoomFactor;
                        clickOffset_Y = (-move_InitialNote + curNote.NoteVal) * verticalZoomFactor;

                        move_InitialNote = curNote.NoteVal;
                        move_InitialTime = curNote.Start;

                        break;
                    case MouseStates.HoverNoteEnd:
                        mousestate = MouseStates.MovingRightEnd;

                        clickOffset_X = (move_InitialTime - curNote.Stop_) * horizontalZoomFactor;
                        clickOffset_Y = (-move_InitialNote + curNote.NoteVal) * verticalZoomFactor;

                        move_InitialNote = curNote.NoteVal;
                        move_InitialTime = curNote.Stop_;
                        
                        break;
                    case MouseStates.MovingNote:
                        double timeChange = 0, noteChange = 0;
                        GetMouseChange(ref timeChange, ref noteChange);
                        Instrument temp = track.TemplateInstrument.GetNewClone();
                        temp.Name = track.TemplateInstrument.Name;
                        rBll.InstrumentSound(temp, move_InitialNote + noteChange);
                        break;
                    default:
                        break;
                }
                rBll.snapHelper.SnapToGrid(ref curMouseTime, ref curMouseNote);
                (sender as PictureBox).Invalidate();
            }
            

            switch (mousestate) // show correct cursor
            {
                case MouseStates.None:
                    form1.Cursor = Cursors.Default;
                    break;
                case MouseStates.HoverNote:
                    form1.Cursor = Cursors.Hand;
                    break;
                case MouseStates.HoverNoteStart:
                    form1.Cursor = Cursors.VSplit;
                    break;
                case MouseStates.HoverNoteEnd:
                    form1.Cursor = Cursors.VSplit;
                    break;
                
                default:
                    break;
            }
        }
        public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseIsDown_left = true;

                move_InitialTime = PosToTime(e.X);
                move_InitialNote = PosToNote(e.Y);


                NoteUnit curNote = track.GetNoteAt(move_InitialTime, move_InitialNote);
                if (curNote == null)
                {
                    track.DeselectAll();
                }
                else
                {
                    curNote.selected = true;
                }
            }
            
            
            
        }

        public void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseIsDown_left = false;

                double noteChange = 0, timeChange = 0;
                switch (mousestate)
                {
                    case MouseStates.MovingNote:
                        //mousestate = MouseStates.None;
                        
                        //double noteChange = 0, timeChange = 0;
                        GetMouseChange(ref timeChange, ref noteChange);
                        track.MoveSelectedNotes(timeChange, noteChange);


                        // Deselect if only one note is selected:
                        DeselectIfOne();
                        break;
                    case MouseStates.MovingLeftEnd:
                        GetMouseChange(ref timeChange, ref noteChange);
                        track.ChangeNoteLengthInSelection(-timeChange);
                        track.MoveSelectedNotes(timeChange, 0);
                        DeselectIfOne();
                        break;
                    case MouseStates.MovingRightEnd:

                        //double noteChange = 0, timeChange = 0;
                        GetMouseChange(ref timeChange, ref noteChange);
                        track.ChangeNoteLengthInSelection(timeChange);
                        DeselectIfOne();
                        break;
                    case MouseStates.Selecting:
                        List<NoteUnit> notesSelected = track.GetNotesInInterval(move_InitialTime, curMouseTime, move_InitialNote, curMouseNote);
                        track.DeselectAll();
                        foreach (NoteUnit item in notesSelected)
                        {
                            item.selected = true;
                        }
                        break;
                    default:
                        break;
                }
                mousestate = MouseStates.None;
                
            }
            else if (e.Button == MouseButtons.Right)
            {
                double timepos = PosToTime(e.X);
                double notepos = PosToNote(e.Y);
                rBll.snapHelper.SnapToGrid(ref timepos, ref notepos);
                //rBll.song.SelectedTrack.AddNote(new Note(timepos, notepos));
                track.DeselectAll();
                track.AddNote(new NoteUnit(timepos, notepos));
            }
            (sender as PictureBox).Invalidate();
        }

        void GetMouseChange(ref double time, ref double note)
        {
            double curNote = PosToNote(NoteToPos(curMouseNote) - clickOffset_Y);
            double curTime = PosToTime(TimeToPos(curMouseTime) - clickOffset_X);
            rBll.snapHelper.SnapToGrid(ref curTime, ref curNote);
            time = curTime - move_InitialTime;
            note = curNote - move_InitialNote;
            //track.MoveSelectedNotes(curTime - mouseDownTime, curNote - mouseDownNote);
        }

        void DeselectIfOne()
        {
            int numSelected = track.Notes.Count(x => x.selected);
            if (numSelected == 1)
            {
                track.DeselectAll();
            }
        }
        
    }

    
}
