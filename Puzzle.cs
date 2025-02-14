﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace _8_Puzzle_Ödevi
{
    
    public enum Heuristic
    {     
        ManhattanDistance
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
    }
    public class State : IComparable
    {
        private int[] mNodes;
        private int mSpaceIndex;
        private string mStateCode;
        private int mCostf;
        private int mCosth;
        private int mCostg;
        private Heuristic mHeuristic;
        private State mParent;

        public State(State parent, int[] nodes, Heuristic heuristic)
        {
            mNodes = nodes;
            mParent = parent;
            mHeuristic = heuristic;
            CalculateCost();
            mStateCode = GenerateStateCode();
        }
        private State(State parent, int[] nodes)
        {
            mNodes = nodes;
            mParent = parent;
            mHeuristic = parent.mHeuristic;
            CalculateCost();
            mStateCode = GenerateStateCode();
        }
        public override bool Equals(object obj)
        {
            State that = obj as State;

            return that != null && this.mStateCode.Equals(that.mStateCode);
        }

        public override int GetHashCode()
        {
            return mStateCode.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            State that = obj as State;

            if (that != null)
            {
                return (this.mCostf).CompareTo(that.mCostf);
            }

            return 0;
        }

        public bool IsCostlierThan(State thatState)
        {
            return this.mCostg > thatState.mCostg;
        }

        public String GetStateCode()
        {
            return mStateCode;
        }
        public void CalculateCost()
        {
            if (mParent == null)
            {
               
                mCostg = 0;
            }
            else
            {
             
                mCostg = mParent.mCostg + 1;
            }

           
            mCosth = GetHeuristicCost();

            mCostf = mCosth + mCostg;
        }
        public int GetHeuristicCost()
        {          
                return GetManhattanDistanceCost();                      
        }
        
        public int GetManhattanDistanceCost()
        {
            int heuristicCost = 0;
            int gridX = (int)Math.Sqrt(mNodes.Length);
            int idealX;
            int idealY;
            int currentX;
            int currentY;
            int value;

            for (int i = 0; i < mNodes.Length; i++)
            {
                value = mNodes[i] - 1;
                if (value == -2)
                {
                    value = mNodes.Length - 1;
                    mSpaceIndex = i;
                }

                if (value != i)
                {
                   
                    idealX = value % gridX;
                    idealY = value / gridX;

                    currentX = i % gridX;
                    currentY = i / gridX;

                    heuristicCost += (Math.Abs(idealY - currentY) + Math.Abs(idealX - currentX));
                }
            }

            return heuristicCost;
        }
        public String GenerateStateCode()
        {
            StringBuilder code = new StringBuilder();

            for (int i = 0; i < mNodes.Length; i++)
            {
                code.Append(mNodes[i] + "*");
            }

            return code.ToString().Trim(new char[] { '*' });
        }

        public int[] GetState()
        {
            int[] state = new int[mNodes.Length];
            Array.Copy(mNodes, state, mNodes.Length);

            return state;
        }

        public bool IsFinalState()
        {
            
            return mCosth == 0;
        }

        public State GetParent()
        {
            return mParent;
        }

        public List<State> GetNextStates(ref List<State> nextStates)
        {
            nextStates.Clear();
            State state;

            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                state = GetNextState(direction);

                if (state != null)
                {
                    nextStates.Add(state);
                }
            }

            return nextStates;
        }
        public State GetNextState(Direction direction)
        {
            int position;

            if (CanMove(direction, out position))
            {
                int[] nodes = new int[mNodes.Length];
                Array.Copy(mNodes, nodes, mNodes.Length);

               
                Swap(nodes, mSpaceIndex, position);

                return new State(this, nodes);
            }

            return null;
        }

        public void Swap(int[] nodes, int i, int j)
        {
            int t = nodes[i];
            nodes[i] = nodes[j];
            nodes[j] = t;
        }

        public bool CanMove(Direction direction, out int newPosition)
        {
            int newX = -1;
            int newY = -1;
            int gridX = (int)Math.Sqrt(mNodes.Length);
            int currentX = mSpaceIndex % gridX;
            int currentY = mSpaceIndex / gridX;
            newPosition = -1;

            switch (direction)
            {
                case Direction.Up:
                    {
                        
                        if (currentY != 0)
                        {
                            newX = currentX;
                            newY = currentY - 1;
                        }
                    }
                    break;

                case Direction.Down:
                    {
                        
                        if (currentY < (gridX - 1))
                        {
                            newX = currentX;
                            newY = currentY + 1;
                        }
                    }
                    break;

                case Direction.Left:
                    {
                       
                        if (currentX != 0)
                        {
                            newX = currentX - 1;
                            newY = currentY;
                        }
                    }
                    break;

                case Direction.Right:
                    {
                        
                        if (currentX < (gridX - 1))
                        {
                            newX = currentX + 1;
                            newY = currentY;
                        }
                    }
                    break;
            }

            if (newX != -1 && newY != -1)
            {
                newPosition = newY * gridX + newX;
            }

            return newPosition != -1;
        }

        public override string ToString()
        {
            return "State:" + mStateCode + ", g:" + mCostg + ", h:" + mCosth + ", f:" + mCostf;
        }
    }

    public delegate void StateChanged(int[] currentState, bool isFinal);
    public delegate void PuzzleSolution(int steps, int time, int stateExamined);

    public  class PuzzleStrategy
    {        
        private Stopwatch mStopWatch;
        public event StateChanged OnStateChanged;
        public event PuzzleSolution OnPuzzleSolved;

        public PuzzleStrategy()
        {
            mStopWatch = new Stopwatch();
        }

        public void Solve(int[] nodes, Heuristic heuristic)
        {
            ThreadPool.QueueUserWorkItem(item => Start(nodes, heuristic));
        }

        public void Start(int[] nodes, Heuristic heuristic)
        {
            int openStateIndex;
            int stateCount = -1;
            State currentState = null;
            List<State> nextStates = new List<State>();
            HashSet<String> openStates = new HashSet<string>();
            MinPriorityQueue<State> openStateQueue = new MinPriorityQueue<State>(nodes.Length * 3);
            Dictionary<String, State> closedQueue = new Dictionary<string, State>(nodes.Length * 3);

            State state = new State(null, nodes, heuristic);
            openStateQueue.Enqueue(state);
            openStates.Add(state.GetStateCode());

            StartMeasure();

            while (!openStateQueue.IsEmpty())
            {
                currentState = openStateQueue.Dequeue();
                openStates.Remove(currentState.GetStateCode());

                stateCount++;

                if (currentState.IsFinalState())
                {
                    EndMeasure(stateCount);
                    break;
                }

                currentState.GetNextStates(ref nextStates);

                if (nextStates.Count > 0)
                {
                    State closedState;
                    State openState;
                    State nextState;

                    for (int i = 0; i < nextStates.Count; i++)
                    {
                        closedState = null;
                        openState = null;
                        nextState = nextStates[i];

                        if (openStates.Contains(nextState.GetStateCode()))
                        {
                            
                            openState = openStateQueue.Find(nextState, out openStateIndex);

                            if (openState.IsCostlierThan(nextState))
                            {
                                
                                openStateQueue.Remove(openStateIndex);
                                openStateQueue.Enqueue(nextState);
                            }
                        }
                        else
                        {
                           
                            String stateCode = nextState.GetStateCode();

                            if (closedQueue.TryGetValue(stateCode, out closedState))
                            {
                                
                                if (closedState.IsCostlierThan(nextState))
                                {
                                    closedQueue.Remove(stateCode);
                                    closedQueue[stateCode] = nextState;
                                }
                            }
                        }
                     
                        if (openState == null && closedState == null)
                        {
                            openStateQueue.Enqueue(nextState);
                            openStates.Add(nextState.GetStateCode());
                        }
                    }

                    closedQueue[currentState.GetStateCode()] = currentState;
                }
            }

            if (currentState != null && !currentState.IsFinalState())
            {               
                currentState = null;
            }

            PuzzleSolved(currentState, stateCount);
            OnFinalState(currentState);
        }

        public void StartMeasure()
        {
            mStopWatch.Reset();
            mStopWatch.Start();
        }

        public void EndMeasure(int stateCount)
        {
            mStopWatch.Stop();
        }

        public void OnFinalState(State state)
        {
            if (state != null)
            {
                
                Stack<State> path = new Stack<State>();

                while (state != null)
                {
                    path.Push(state);
                    state = state.GetParent();
                }

                while (path.Count > 0)
                {
                    
                    OnStateChanged(path.Pop().GetState(), path.Count == 0);
                }
            }
            else
            {
                
                OnStateChanged(null, true);
            }
        }

        public void PuzzleSolved(State state, int states)
        {
            int steps = -1;

            while (state != null)
            {
                state = state.GetParent();
                steps++;
            }

            if (OnPuzzleSolved != null)
            {
                OnPuzzleSolved(steps, (int)mStopWatch.ElapsedMilliseconds, states);
            }
        }

       
    }

    public class MinPriorityQueue<T> where T : IComparable
    {
       
        public T[] mArray;
        public int mCount;

        public MinPriorityQueue(int capacity)
        {
            mArray = new T[capacity + 1];
            mCount = 0;
        }

        public void Expand(int capacity)
        {
            T[] temp = new T[capacity + 1];
            int i = 0;
            while (++i <= mCount)
            {
                temp[i] = mArray[i];
                mArray[i] = default(T);
            }

            mArray = temp;
        }

        public bool Less(int i, int j)
        {
            return mArray[i].CompareTo(mArray[j]) < 0;
        }

        public void Swap(int i, int j)
        {
            T temp = mArray[j];
            mArray[j] = mArray[i];
            mArray[i] = temp;
        }

        public void Sink(int index)
        {
            int k;
            while (index * 2 <= mCount)
            {
                k = index * 2;

                if (k + 1 <= mCount && Less(k + 1, k))
                {
                    k = k + 1;
                }

                if (!Less(k, index))
                {
                    break;
                }

                Swap(index, k);
                index = k;
            }
        }

        public void Swim(int index)
        {
            int k;

            while (index / 2 > 0)
            {
                k = index / 2;

                if (!Less(index, k))
                {
                    break;
                }

                Swap(index, k);
                index = k;
            }
        }

        public bool IsEmpty()
        {
            return mCount == 0;
        }

        public void Enqueue(T item)
        {
            if (mCount == mArray.Length - 1)
            {
                Expand(mArray.Length * 3);
            }

            mArray[++mCount] = item;
            Swim(mCount);
        }

        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T item = mArray[1];
                mArray[1] = mArray[mCount];
                mArray[mCount--] = default(T);

                Sink(1);

                return item;
            }

            return default(T);
        }

        public T Find(T item, out int index)
        {
            index = -1;
            if (!IsEmpty())
            {
                int i = 0;

                while (++i <= mCount)
                {
                    if (mArray[i].Equals(item))
                    {
                        index = i;
                        return mArray[i];
                    }
                }
            }

            return default(T);
        }

        public void Remove(int index)
        {
            if (index > 0 && index <= mCount)
            {
                mArray[index] = mArray[mCount];
                mArray[mCount--] = default(T);
                Sink(index);
            }
        }     
    }

    public class LinearShuffle<T>
    {

        public Random mRandom;


        public LinearShuffle()
        {
            int seed = 37 + 37 * ((int)DateTime.Now.TimeOfDay.TotalSeconds % 37);
            mRandom = new Random(seed);
        }

        public void Shuffle(T[] array)
        {
            int position;
            for (int i = 0; i < array.Length; i++)
            {
                position = NextRandom(0, i);
                Swap(array, i, position);
            }
        }

        public int NextRandom(int min, int max)
        {
            return mRandom.Next(min, max);
        }

        public void Swap(T[] a, int i, int j)
        {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
 
