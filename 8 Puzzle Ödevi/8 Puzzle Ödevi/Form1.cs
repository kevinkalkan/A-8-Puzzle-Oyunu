using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace _8_Puzzle_Ödevi
{
    public partial class Form1 : Form
    {
        public PuzzleStrategy mStrategy;
        public Heuristic mHeuristic;
        public LinearShuffle<int> mShuffle;
        public WindowsFormsSynchronizationContext mSyncContext;
        Dictionary<int, Button> mButtons;
        public int[] mInitialState;
        public bool mBusy;

        public Form1()
        {
            InitializeComponent();
            mSyncContext = SynchronizationContext.Current as WindowsFormsSynchronizationContext;

            Initialize();
        }

        public void Initialize()
        {
            mInitialState = new int[] { 8, 7, 2, 4, 6, 3, 1, -1, 5 };

            mShuffle = new LinearShuffle<int>();
            mStrategy = new PuzzleStrategy();
            mHeuristic = Heuristic.ManhattanDistance;
            mStrategy.OnStateChanged += OnStrategyStateChanged;
            mStrategy.OnPuzzleSolved += OnPuzzleSolved;

          
            mButtons = new Dictionary<int, Button>();
            mButtons[0] = button1;
            mButtons[1] = button2;
            mButtons[2] = button3;
            mButtons[3] = button4;
            mButtons[4] = button5;
            mButtons[5] = button6;
            mButtons[6] = button7;
            mButtons[7] = button8;
            mButtons[8] = button9;

            
            DisplayState(mInitialState, false);

         
        }
        private void OnStrategyStateChanged(int[] state, bool isFinal)
        {
            mSyncContext.Post(item => DisplayState(state, isFinal), null);
            Thread.Sleep(500);
        }
        private void SwapValues(int x, int y)
        {
            int temp = mInitialState[x];
            mInitialState[x] = mInitialState[y];
            mInitialState[y] = temp;
        }

        private void OnPuzzleSolved(int steps, int time, int statesExamined)
        {
            Action action = () =>
            {
               
                if (steps > -1)
                {
                    
                    MessageBox.Show(this, "Çözüm Bulundu!");
                }
                else
                {
                    
                    MessageBox.Show(this, "Çözüm Bulunamadı!");
                }
            };

            mSyncContext.Send(item => action.Invoke(), null);
        }

        private void DisplayState(int[] nodes, bool isFinal)
        {
            if (nodes != null)
            {
                this.gamePanel.SuspendLayout();

                for (int i = 0; i < nodes.Length; i++)
                {
                    if (nodes[i] > 0)
                    {
                        mButtons[i].Text = nodes[i].ToString();
                    }
                    else
                    {
                        mButtons[i].Text = null;
                    }
                }

                this.gamePanel.ResumeLayout();
            }

            if (isFinal)
            {
                mBusy = false;
                buttonShuffle.Enabled = true;
                buttonStart.Enabled = true;
            }
        }

        private void StartSolvingPuzzle()
        {
            mStrategy.Solve(mInitialState, mHeuristic);           
            this.Cursor = Cursors.WaitCursor;           
            mBusy = true;
        }

        private bool ActionAllowed()
        {
            return !mBusy;
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActionAllowed())
            {
                Button button = sender as Button;

                if (button != null && button.Tag != null)
                {
                    int value;
                    Button tileButton;

                    if (int.TryParse(button.Tag.ToString(), out value) && mButtons.TryGetValue(value, out tileButton) && button == tileButton)
                    {
                        button.DoDragDrop(button.Tag, DragDropEffects.Copy | DragDropEffects.Move);
                    }
                }
            }
        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            if (ActionAllowed())
            {
                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void Button_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (ActionAllowed())
            {
                Button button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    int dropValue;
                    Button buttonToDrop;

                    if (int.TryParse(button.Tag.ToString(), out dropValue) && mButtons.TryGetValue(dropValue, out buttonToDrop) && button == buttonToDrop)
                    {
                        int dragValue;

                        if (int.TryParse(e.Data.GetData(DataFormats.Text).ToString(), out dragValue) && dropValue != dragValue)
                        {
                            SwapValues(dragValue, dropValue);
                            DisplayState(mInitialState, false);
                        }
                    }
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (ActionAllowed())
            {
                StartSolvingPuzzle();
            }
        }
     
        private void ExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            if (ActionAllowed())
            {
                mShuffle.Shuffle(mInitialState);
                
                DisplayState(mInitialState, false);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (ActionAllowed())
            {
                StartSolvingPuzzle();
            }
        }

        
    }
}