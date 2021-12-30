using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAndVisitorMS
{
    internal class MergeSort
    {
        public TicketDetails[] MergeSorter(string sortBy, TicketDetails[] ticketDetails)
        {
            if (ticketDetails.Length <= 1)
            {
                return ticketDetails;
            }
            int midpoint = ticketDetails.Length / 2;
            TicketDetails[] left = new TicketDetails[midpoint];
            TicketDetails[] right = new TicketDetails[ticketDetails.Length - left.Length];
            for (int i = 0; i < midpoint; i++)
            {
                left[i] = ticketDetails[i];
            }
            for (int j = 0; j < right.Length; j++)
            {
                right[j] = ticketDetails[midpoint + j];
            }
            left = MergeSorter(sortBy, left);
            right = MergeSorter(sortBy, right);
            TicketDetails[] result = Merge(left, right, sortBy);
            return result;
        }

        public TicketDetails[] Merge(TicketDetails[] left, TicketDetails[] right, string sortBy)
        {
            TicketDetails[] result = new TicketDetails[left.Length + right.Length];
            int leftPointer, rightPointer, resultPointer;
            leftPointer = rightPointer = resultPointer = 0;
            while (leftPointer < left.Length || rightPointer < right.Length)
            {
                if (leftPointer < left.Length && rightPointer < right.Length)
                {
                    if (CheckCondition(left, right, leftPointer, rightPointer, sortBy))
                    {
                        result[resultPointer++] = left[leftPointer++];
                    }
                    else
                    {
                        result[resultPointer++] = right[rightPointer++];
                    }
                }
                else if (leftPointer < left.Length)
                {
                    result[resultPointer++] = left[leftPointer++];
                }
                else
                {
                    result[resultPointer++] = right[rightPointer++];
                }
            }
            return result;
        }

        private bool CheckCondition(TicketDetails[] ticketDetails1, TicketDetails[] ticketDetails2, int firstIndex, int secondIndex, string sortBy)
        {
            if (sortBy == "Price")
            {
                return ticketDetails1[firstIndex].ticketPrice < ticketDetails2[secondIndex].ticketPrice;
            }
            else if (sortBy == "Ticket Info ID")
            {
                return CheckStringCondition(ticketDetails1[firstIndex].ticketID, ticketDetails2[secondIndex].ticketID);
            }
            else if (sortBy == "Category")
            {
                return CheckStringCondition(ticketDetails1[firstIndex].ticketCategory, ticketDetails2[secondIndex].ticketCategory);
            }
            else if (sortBy == "Day")
            {
                return CheckStringCondition(ticketDetails1[firstIndex].ticketDay, ticketDetails2[secondIndex].ticketDay);
            }
            else if (sortBy == "Duration")
            {
                return CheckStringCondition(ticketDetails1[firstIndex].ticketDuration, ticketDetails2[secondIndex].ticketDuration);
            }
            else { return false; }
        }

        private bool CheckStringCondition(string str1, string str2)
        {
            if (string.Compare(str1, str2) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}