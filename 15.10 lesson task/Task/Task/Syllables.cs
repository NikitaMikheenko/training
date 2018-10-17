using System;
using System.Linq;

namespace Task
{
    static class Syllables
    {
        static string[] _letters = new string[] {"пПфФкКтТсСшШхЧцЦчЧщЩбБвВгГдДжЖзЗлЛмМнНрРйЙ", "аАеЕёЁиИоОуУыЫэЭюЮяЯ"};

        public static string SyllableDivision(string str)
        {
            bool isfinished = true;

            for (int i = 0; i < str.Length; i++)
            {
                if (LetterType(str[i]) == 2)
                {
                    isfinished = false;
                }

                if (0 < i && i < str.Length - 1)
                {
                    if (LetterType(str[i - 1]) == 2)
                    {
                        if (LetterType(str[i]) == 1)
                        {
                            if (LetterType(str[i + 1]) == 1)
                            {
                                str = str.Insert(i + 1, "-");
                                isfinished = true;
                            }
                            else if (LetterType(str[i + 1]) == 2)
                            {
                                str = str.Insert(i, "-");
                                isfinished = true;
                            }
                        }
                        else if (LetterType(str[i]) == 2)
                        {
                            str = str.Insert(i, "-");
                            isfinished = true;
                        }
                    }
                    else if (LetterType(str[i - 1]) == 1)
                    {
                        if ((str[i] == 'ъ' || str[i] == 'ь') && ((LetterType(str[i + 1]) == 1) || (LetterType(str[i + 1]) == 2)) && !isfinished)
                        {
                            str = str.Insert(i + 1, "-");
                            isfinished = true;
                        }
                    }
                }
            }
            return str;
        }

        private static int LetterType(char l)
        {
            for (int i = 0; i < _letters.Length; i++)
            {
                if (_letters[i].Contains(l))
                {
                    return i + 1;
                }
            }
            return 0;
        }
    }
}
