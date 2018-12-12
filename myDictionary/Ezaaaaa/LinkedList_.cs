using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezaaaaa
{
   public  class LinkedList_
    {

        public NODE Head;
        
        public LinkedList_()
        {
            Head = null;         
        }


        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            else
                return false;
        }



        public void Insert(string value)
        {
            NODE newNode = new NODE(value);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                NODE current = Head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;

            }

        }
        public int Length()
        {
            int i = 0;
            NODE current = Head;
            while (current != null)
            {

                current = current.next;
                i++;

            }
            return i;

        }



        public string Search(string value)
        {
            NODE temp = Head;               //Temporary node to traverse
            bool state = false;

            while (temp != null)
            {
                if (temp.data == value)
                {
                    
                    state = true;
                    return temp.data;
                }
                else
                    temp = temp.next;
            }

            if (state == false)
            {
               // Console.WriteLine("Value Not Found");

            }
            return "-999";
        }

        public void deleteAll()
        {
            NODE current = Head;
            NODE tempPrevious = null;
            while (current != null)
            {
                tempPrevious = current.next;

                current = null;
            }
            Head = null;
        }
        public void Delete(string value)
        {
            NODE current = Head;
            NODE tempPrevious = null;

            if (IsEmpty() == true)
            {
                Console.WriteLine("LINKEDLIST IS EMPTY");
            }

            else
            {

                if (Head.data == value)
                {
                    Head = Head.next;
                }

                else
                {
                    while (current != null)
                    {
                        if (current.data == value)
                        {
                            tempPrevious.next = current.next;
                            current = null;
                        }
                        else
                        {
                            tempPrevious = current;
                            current = current.next;
                        }
                    }
                }
            }


        }
     




        public string Get(int index)
        {
            NODE current = Head;
            int count = 0; 
            while (current != null)
            {
                if (count == index)
                    return current.data;
                count++;
                current = current.next;
            }


            return null;
        }
    }
}
