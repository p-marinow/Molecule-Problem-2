using System;
using System.ComponentModel.DataAnnotations;

namespace Exam
{
    public class AtomCharacteristics
    {
        [Range(-6, 6)] sbyte kwark;
        [Range(0, 1024)] ushort? isotop; //nullable
    }
}
