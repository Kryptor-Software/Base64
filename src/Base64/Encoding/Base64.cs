﻿using System;
using System.Text;
using System.Windows.Forms;

/*  
    Base64: Convert strings to/from Base64 on Windows.
    Copyright(C) 2020 Samuel Lucas

    Permission is hereby granted, free of charge, to any person obtaining 
    a copy of this software and associated documentation files (the "Software"), 
    to deal in the Software without restriction, including without limitation 
    the rights to use, copy, modify, merge, publish, distribute, sublicense, 
    and/or sell copies of the Software, and to permit persons to whom the 
    Software is furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
    OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

namespace Base64
{
    public static class Base64
    {
        public static char[] EncodeMessage(char[] message)
        {
            try
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                string base64 = Convert.ToBase64String(messageBytes);
                return base64.ToCharArray();
            }
            catch (EncoderFallbackException)
            {
                MessageBox.Show("Error: Unable to encode characters.");
                return null;
            }
        }

        public static char[] DecodeMessage(char[] message)
        {
            try
            {
                byte[] messageBytes = Convert.FromBase64CharArray(message, 0, message.Length);
                char[] decodedMessage = Encoding.UTF8.GetChars(messageBytes);
                return decodedMessage;
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Message is not in a valid Base64 format.");
                return null;
            }
            catch (DecoderFallbackException)
            {
                MessageBox.Show("Error: Unable to decode characters.");
                return null;
            }
        }
    }
}
