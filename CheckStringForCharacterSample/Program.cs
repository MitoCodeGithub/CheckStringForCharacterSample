using CheckStringForCharacterSample.functions;
using System;
using System.Collections.Generic;

namespace CheckStringForCharacterSample
{
    class Program
    {
        private static readonly List<char> ALLOWED_CHAR = new List<char>();
        private static readonly List<int> IGNORED_GROUP = new List<int>();

        /// <summary>
        /// Fill both lists
        /// </summary>
        static private void Adder() {
            ALLOWED_CHAR.Add('1');
            ALLOWED_CHAR.Add('2');
            ALLOWED_CHAR.Add('3');
            ALLOWED_CHAR.Add('4');
            ALLOWED_CHAR.Add('5');
            ALLOWED_CHAR.Add('6');
            ALLOWED_CHAR.Add('7');
            ALLOWED_CHAR.Add('8');
            ALLOWED_CHAR.Add('9');
            ALLOWED_CHAR.Add('0');
            ALLOWED_CHAR.Add('A');
            ALLOWED_CHAR.Add('B');
            ALLOWED_CHAR.Add('C');
            ALLOWED_CHAR.Add('D');
            ALLOWED_CHAR.Add('E');
            ALLOWED_CHAR.Add('F');
            ALLOWED_CHAR.Add('G');
            ALLOWED_CHAR.Add('H');
            ALLOWED_CHAR.Add('I');
            ALLOWED_CHAR.Add('J');
            ALLOWED_CHAR.Add('K');
            ALLOWED_CHAR.Add('L');
            ALLOWED_CHAR.Add('M');
            ALLOWED_CHAR.Add('N');
            ALLOWED_CHAR.Add('O');
            ALLOWED_CHAR.Add('P');
            ALLOWED_CHAR.Add('Q');
            ALLOWED_CHAR.Add('R');
            ALLOWED_CHAR.Add('S');
            ALLOWED_CHAR.Add('T');
            ALLOWED_CHAR.Add('U');
            ALLOWED_CHAR.Add('V');
            ALLOWED_CHAR.Add('W');
            ALLOWED_CHAR.Add('X');
            ALLOWED_CHAR.Add('Y');
            ALLOWED_CHAR.Add('Z');
            ALLOWED_CHAR.Add('Ä');
            ALLOWED_CHAR.Add('Ö');
            ALLOWED_CHAR.Add('Ü');
            ALLOWED_CHAR.Add('_');
            ALLOWED_CHAR.Add('@');
            ALLOWED_CHAR.Add('\'');
            ALLOWED_CHAR.Add(' ');

            IGNORED_GROUP.Add(1);
            IGNORED_GROUP.Add(2);
            IGNORED_GROUP.Add(3);
        }

        static void Main(string[] args) {
            Adder();
            Console.Title = "CheckStringForCharacterSample";
            Console.ForegroundColor = ConsoleColor.White;

            #region GroupList
            /* 
             * Available commands for GroupList:
             * 
             * ClientInfo.GroupList = null (no server groups)
             * ClientInfo.GroupList = "1" (one server group (listed in IGNORED_GROUP))
             * ClientInfo.GroupList = "1,2,3,..." (more than one server group (can be listed or not in IGNORED_GROUP))
             *      If client has server group 1, 2 or 3, CheckUsername() will be ignored while this groups are listed in IGNORED_GROUP.
             *      If client has another server group, CheckUsername() will not be ignored while she is not listed in IGNORED_GROUP.
             */
            ClientInfo.GroupList = "1,2,3";
            #endregion GroupList

            int myGroupIDs = ClientInfo.getServerGroups()[0];

            CheckUsername("Test", myGroupIDs);
        }

        /// <summary>
        /// Check all groups (<paramref name="groupIDs"/>) of the client and check the nickname (<paramref name="username"/>)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="groupIDs"></param>
        private static void CheckUsername(string username, int groupIDs) {

            //check for nickname lengh
            if (username.Length > 30 || username.Length < 3) {
                Console.WriteLine("Invalid nickname.");
                Console.ReadLine();
                return;
            }

            //check for client server groups
            foreach (int group in IGNORED_GROUP) {
                if (ClientInfo.isInServerGroup(group)) {
                    Console.WriteLine($"Client ignored because of server group {groupIDs}.");
                    Console.ReadLine();
                    return;
                }
            }

            int nameLengh = username.Length;
            int allowedChars = 0;
            int index = 0;
            char check;

            while (index < nameLengh) {
                //every single char will be checked
                check = username[index];

                //upper case char
                foreach (char c in ALLOWED_CHAR) {
                    if (check == c)
                        allowedChars++;
                }

                //lower case char
                foreach (char ch in ALLOWED_CHAR) {
                    char cha = char.ToLower(ch);
                    if (check == cha)
                        allowedChars++;
                }

                //get the next char from 'username'
                index++;
            }

            if (nameLengh == allowedChars)
            {
                Console.WriteLine("Nickname allowed.");
                /*
                 * Do some stuff here...
                 */
            }
            else
            {
                Console.WriteLine("Nickname not allowed.");
                /*
                 * Do some stuff here...
                 */
            }

            //keep the console open
            Console.ReadLine();
        }
    }
}