using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text;

namespace Java.EditorExtensions
{
    internal static class ArrayExtension
    {
        private static bool IsNewLineChar(char character)
        {
            return (character == '\r' || character == '\n');
        }
        private static int GetNewLineLength(string line)
        {
            int length = 0;

            for (int i = line.Length - 1; (i >= 0 && IsNewLineChar(line[i])); i--)
            {
                length++;
            }

            return length;
        }

        public static int[] GetNewLineLengths(this System.Array lines)
        {
            if (lines == null)
                return null;

            int[] lengths = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                lengths[i] = GetNewLineLength((string)lines.GetValue(i));
            }

            return lengths;
        }
    }
}