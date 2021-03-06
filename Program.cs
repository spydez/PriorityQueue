﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{

public class Program
{
   private static void AssertTrue(bool value, string message = "Assert failed.")
   {
      if (!value)
         throw new ArgumentException(message);
   }

   public static void Main(string[] args)
   {
      Console.WriteLine("PriorityQueue unit tests...");

      // SortedSet
      TestMin();
      TestMax();
      TestMixed();
      TestOverDequeueMin();
      TestOverDequeueMax();

      // IntervalHeap
      TestMinHeap();
      TestMaxHeap();
      TestMixedHeap();
      TestOverDequeueMinHeap();
      TestOverDequeueMaxHeap();

      Console.WriteLine("Done.");
   }

   private static void TestMin()
   {
      Console.Write("  TestMin");

      PriorityQueue<string> strQueue = new PriorityQueue<string>(new SortedSetStore<string>());
      strQueue.Enqueue("high", 100);
      strQueue.Enqueue("low", -100);
      strQueue.Enqueue("zero", 0);

      AssertTrue(strQueue.Count == 3);

      string temp = strQueue.DequeueMin();
      AssertTrue(temp == "low");
      temp = strQueue.DequeueMin();
      AssertTrue(temp == "zero");
      temp = strQueue.DequeueMin();
      AssertTrue(temp == "high");

      AssertTrue(strQueue.Count == 0);
           
      Console.WriteLine(" - Pass");
   }

   private static void TestMax()
   {
      Console.Write("  TestMax");

      PriorityQueue<string> strQueue = new PriorityQueue<string>(new SortedSetStore<string>());
      strQueue.Enqueue("high", 100);
      strQueue.Enqueue("low", -100);
      strQueue.Enqueue("zero", 0);

      AssertTrue(strQueue.Count == 3);

      string temp = strQueue.DequeueMax();
      AssertTrue(temp == "high");
      temp = strQueue.DequeueMax();
      AssertTrue(temp == "zero");
      temp = strQueue.DequeueMax();
      AssertTrue(temp == "low");

      AssertTrue(strQueue.Count == 0);
           
      Console.WriteLine(" - Pass");
   }

   private static void TestMixed()
   {
      Console.Write("  TestMixed");

      PriorityQueue<int> intQueue = new PriorityQueue<int>(new SortedSetStore<int>());
      for (int i = 0; i < 10; i++)
         intQueue.Enqueue(i, i);

      AssertTrue(intQueue.Count == 10);

      int temp = intQueue.DequeueMax();
      AssertTrue(temp == 9);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 0);
      temp = intQueue.DequeueMax();
      AssertTrue(temp == 8);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 1);
      temp = intQueue.DequeueMax();
      AssertTrue(temp == 7);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 2);
      temp = intQueue.DequeueMax();
      AssertTrue(temp == 6);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 3);
      temp = intQueue.DequeueMax();
      AssertTrue(temp == 5);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 4);

      AssertTrue(intQueue.Count == 0);
           
      Console.WriteLine(" - Pass");
   }

   private static void TestOverDequeueMin()
   {
      Console.Write("  TestOverDequeueMin");

      PriorityQueue<int> intQueue = new PriorityQueue<int>(new SortedSetStore<int>());
      for (int i = 0; i < 10; i++)
         intQueue.Enqueue(i, i);

      AssertTrue(intQueue.Count == 10);

      for (int i = 0; i < 10; i++)
         intQueue.DequeueMin();

      try
      {
         // should throw PriorityQueueException
         intQueue.DequeueMin();
      }
      catch (PriorityQueueException)
      {
         Console.WriteLine(" - Pass");
         return;
      }
      catch
      {
         // shouldn't get here - test failed if we did
         AssertTrue(false);
      }

      // shouldn't get here - test failed if we did
      AssertTrue(false);
   }

   private static void TestOverDequeueMax()
   {
      Console.Write("  TestOverDequeueMax");

      PriorityQueue<int> intQueue = new PriorityQueue<int>(new SortedSetStore<int>());
      for (int i = 0; i < 10; i++)
         intQueue.Enqueue(i, i);

      AssertTrue(intQueue.Count == 10);

      for (int i = 0; i < 10; i++)
         intQueue.DequeueMax();

      try
      {
         // should throw PriorityQueueException
         intQueue.DequeueMax();
      }
      catch (PriorityQueueException)
      {
         Console.WriteLine(" - Pass");
         return;
      }
      catch
      {
         // shouldn't get here - test failed if we did
         AssertTrue(false);
      }

      // shouldn't get here - test failed if we did
      AssertTrue(false);
   }

   private static void TestMinHeap()
   {
      Console.Write("  TestMinHeap");

      PriorityQueue<string> strQueue = new PriorityQueue<string>(new IntervalHeapStore<string>());
      strQueue.Enqueue("high", 100);
      strQueue.Enqueue("low", -100);
      strQueue.Enqueue("zero", 0);

      AssertTrue(strQueue.Count == 3);

      string temp = strQueue.DequeueMin();
      AssertTrue(temp == "low");
      temp = strQueue.DequeueMin();
      AssertTrue(temp == "zero");
      temp = strQueue.DequeueMin();
      AssertTrue(temp == "high");

      AssertTrue(strQueue.Count == 0);
           
      Console.WriteLine(" - Pass");
   }


   private static void TestMaxHeap()
   {
      Console.Write("  TestMaxHeap");

      PriorityQueue<string> strQueue = new PriorityQueue<string>(new IntervalHeapStore<string>());
      strQueue.Enqueue("high", 100);
      strQueue.Enqueue("low", -100);
      strQueue.Enqueue("zero", 0);

      AssertTrue(strQueue.Count == 3);

      string temp = strQueue.DequeueMax();
      AssertTrue(temp == "high");
      temp = strQueue.DequeueMax();
      AssertTrue(temp == "zero");
      temp = strQueue.DequeueMax();
      AssertTrue(temp == "low");

      AssertTrue(strQueue.Count == 0);
           
      Console.WriteLine(" - Pass");
   }

   private static void TestMixedHeap()
   {
      Console.Write("  TestMixedHeap");

      PriorityQueue<int> intQueue = new PriorityQueue<int>(new IntervalHeapStore<int>());
      for (int i = 0; i < 10; i++)
         intQueue.Enqueue(i, i);

      AssertTrue(intQueue.Count == 10);

      int temp = intQueue.DequeueMax();
      AssertTrue(temp == 9);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 0);
      temp = intQueue.DequeueMax();
      AssertTrue(temp == 8);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 1);
      temp = intQueue.DequeueMax();
      AssertTrue(temp == 7);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 2);
      temp = intQueue.DequeueMax();
      AssertTrue(temp == 6);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 3);
      temp = intQueue.DequeueMax();
      AssertTrue(temp == 5);
      temp = intQueue.DequeueMin();
      AssertTrue(temp == 4);

      AssertTrue(intQueue.Count == 0);
           
      Console.WriteLine(" - Pass");
   }

   private static void TestOverDequeueMinHeap()
   {
      Console.Write("  TestOverDequeueMinHeap");

      PriorityQueue<int> intQueue = new PriorityQueue<int>(new IntervalHeapStore<int>());
      for (int i = 0; i < 10; i++)
         intQueue.Enqueue(i, i);

      AssertTrue(intQueue.Count == 10);

      for (int i = 0; i < 10; i++)
         intQueue.DequeueMin();

      try
      {
         // should throw PriorityQueueException
         intQueue.DequeueMin();
      }
      catch (PriorityQueueException)
      {
         Console.WriteLine(" - Pass");
         return;
      }
      catch
      {
         // shouldn't get here - test failed if we did
         AssertTrue(false);
      }

      // shouldn't get here - test failed if we did
      AssertTrue(false);
   }

   private static void TestOverDequeueMaxHeap()
   {
      Console.Write("  TestOverDequeueMaxHeap");

      PriorityQueue<int> intQueue = new PriorityQueue<int>(new IntervalHeapStore<int>());
      for (int i = 0; i < 10; i++)
         intQueue.Enqueue(i, i);

      AssertTrue(intQueue.Count == 10);

      for (int i = 0; i < 10; i++)
         intQueue.DequeueMax();

      try
      {
         // should throw PriorityQueueException
         intQueue.DequeueMax();
      }
      catch (PriorityQueueException)
      {
         Console.WriteLine(" - Pass");
         return;
      }
      catch
      {
         // shouldn't get here - test failed if we did
         AssertTrue(false);
      }

      // shouldn't get here - test failed if we did
      AssertTrue(false);
   }
}

}
