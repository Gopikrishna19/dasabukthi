using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public class Evaluate
{
    private int naksvalue = 0;
    private int udnavalue = 0;
    private int munavalue = 0;
    private int nairvalue = 0;
    private double selluvalue = 0.0;
    private double irupuvalue = 0.0;

    public int Naks
    {
        set
        {
            naksvalue = value;
        }
    }
    public int UdNa
    {
        set
        {
            udnavalue = value;
        }
    }
    public int MuNa
    {
        set
        {
            munavalue = value;
        }
    }
    public int NaIr
    {
        set
        {
            nairvalue = value;
        }
    }

    public Result Evaluate(bool reEval, int patham = 1)
    {
        if (naksvalue == 0)
            return Result.NaksError;
        if (udnavalue == nairvalue | munavalue == udnavalue)
            return Result.TimeError;
        if (udnavalue > nairvalue & udnavalue < munavalue)
            return Result.TimeError;
        int f;
        int s;
        int i;
        s = udnavalue - munavalue; // 950 - 350 = 600
        if (s < 0)
            s += 3600;// x
        f = nairvalue - munavalue + 3600; // 3600 - 350 + 3600 = 6850
        if (f > 4000 & !reEval)
            return Result.SameError;
        // MsgBox(f.ToString)
        if (f > 4000)
        {
            f -= 3600;
            goto a;
        }
        if (udnavalue > munavalue & udnavalue < nairvalue)
        {
            if (!reEval)
                return Result.PathError;
            else if (patham == 4)
                s += 3600;
        }

    a:
        ;
        i = f - s;
        selluvalue = s * naksvalue / (double)f;
        irupuvalue = i * naksvalue / (double)f;
        // MsgBox(selluvalue.ToString + " " + irupuvalue.ToString + " " + f.ToString)
        return Result.Success;
    }

    public double Sellu
    {
        get
        {
            return selluvalue;
        }
    }
    public double Iruppu
    {
        get
        {
            return irupuvalue;
        }
    }
}
