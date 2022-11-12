using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    public static PowerManager instance;

    private void Awake()
    {
        instance = this;
    }
    
}

public static class PowerPlayer
{
    static float expNeed;
    public static float GetExpNeedToNextLevel(int level)
    {
        expNeed = 20 * Mathf.Pow(1.2f, level);
        return expNeed;
    }
}

public static class PowerSlime
{
    static float power;
    public static float GetPowerSlime(int level)
    {
        //I dont know how to linq and using json so I will use switch case
        switch (level)
        {
            case 1: power = 1.0622466f; break;
            case 2: power = 1.2510165f; break;
            case 3: power = 1.5787139f; break;
            case 4: power = 2.0008245f; break;
            case 5: power = 2.5501356f; break;
            case 6: power = 3.174321f; break;
            case 7: power = 3.8874958f; break;
            case 8: power = 4.7376523f; break;
            case 9: power = 5.7489767f; break;
            case 10: power = 6.7998996f; break;
            case 11: power = 7.924307f; break;
            case 12: power = 9.141102f; break;
            case 13: power = 10.449758f; break;
            case 14: power = 11.940583f; break;
            case 15: power = 13.671848f; break;
            case 16: power = 15.362399f; break;
            case 17: power = 17.015484f; break;
            case 18: power = 19.015383f; break;
            case 19: power = 20.938461f; break;
            case 20: power = 23.058475f; break;
            case 21: power = 25.128784f; break;
            case 22: power = 27.37476f; break;
            case 23: power = 29.827597f; break;
            case 24: power = 32.700043f; break;
            case 25: power = 35.308243f; break;
            case 26: power = 38.11121f; break;
            case 27: power = 41.128567f; break;
            case 28: power = 43.919365f; break;
            case 29: power = 46.55927f; break;
            case 30: power = 50.10773f; break;
            case 31: power = 53.248135f; break;
            case 32: power = 56.564285f; break;
            case 33: power = 60.12506f; break;
            case 34: power = 63.74705f; break;
            case 35: power = 67.16819f; break;
            case 36: power = 70.87172f; break;
            case 37: power = 75.00188f; break;
            case 38: power = 78.326935f; break;
            case 39: power = 83.070274f; break;
            case 40: power = 87.67316f; break;
            case 41: power = 90.81003f; break;
            case 42: power = 96.54373f; break;
            case 43: power = 100.92854f; break;
            case 44: power = 104.799835f; break;
            case 45: power = 110.13216f; break;
            case 46: power = 227.89426f; break;
            case 47: power = 239.34897f; break;
            case 48: power = 250.501f; break;
            case 49: power = 258.86618f; break;
            case 50: power = 269.8327f; break;
            case 51: power = 283.2059f; break;
            case 52: power = 291.4602f; break;
            case 53: power = 302.29745f; break;
            case 54: power = 312.3048f; break;
            case 55: power = 327.22513f; break;
            case 56: power = 338.7534f; break;
            case 57: power = 348.91837f; break;
            case 58: power = 365.2301f; break;
            case 59: power = 376.36432f; break;
            case 60: power = 390.0156f; break;
            case 61: power = 398.56516f; break;
            case 62: power = 417.18814f; break;
            case 63: power = 427.716f; break;
            case 64: power = 439.56042f; break;
            case 65: power = 452.07956f; break;
            case 66: power = 704.22534f; break;
            case 67: power = 722.02167f; break;
            case 68: power = 738.5524f; break;
            case 69: power = 763.35876f; break;
            case 70: power = 786.1635f; break;
            case 71: power = 806.4516f; break;
            case 72: power = 831.2552f; break;
            case 73: power = 858.3691f; break;
            case 74: power = 888.0995f; break;
            case 75: power = 903.34235f; break;
            case 76: power = 932.8358f; break;
            case 77: power = 956.02295f; break;
            case 78: power = 978.4736f; break;
            case 79: power = 1000f; break;
            case 80: power = 1375.5159f; break;
            case 81: power = 1400.5602f; break;
            case 82: power = 1440.9222f; break;
            case 83: power = 1472.754f; break;
            case 84: power = 1508.2957f; break;
            case 85: power = 1533.7423f; break;
            case 86: power = 1582.2784f; break;
            case 87: power = 1618.1229f; break;
            case 88: power = 1661.1295f; break;
            case 89: power = 1692.0474f; break;
            case 90: power = 1718.213f; break;
            case 91: power = 1760.5634f; break;
            case 92: power = 1801.8018f; break;
            case 93: power = 2309.4688f; break;
            case 94: power = 2352.9412f; break;
            case 95: power = 2409.6387f; break;
            case 96: power = 2450.9805f; break;
            case 97: power = 2500f; break;
            case 98: power = 2564.1025f; break;
            case 99: power = 2631.5789f; break;
            case 100: power = 2645.5027f; break;
            default: power = 2645.5027f; break;
        }
        return power;
    }
}
public static class PowerKoboltRanger
{
    static float dFactor;
    static float aFactor = 5f;
    static float power;
    public static float GetPowerKoboltRanger(int level)
    {
        //I dont know how to linq and using json so I will use switch case
        switch (level)
        {
            case 1: power = 3.262281f; break;
            case 2: power = 4.1087503f; break;
            case 3: power = 5.374177f; break;
            case 4: power = 7.171852f; break;
            case 5: power = 9.362419f; break;
            case 6: power = 11.81628f; break;
            case 7: power = 14.79684f; break;
            case 8: power = 18.438278f; break;
            case 9: power = 22.173933f; break;
            case 10: power = 26.56113f; break;
            case 11: power = 31.453465f; break;
            case 12: power = 36.37819f; break;
            case 13: power = 41.69968f; break;
            case 14: power = 48.513073f; break;
            case 15: power = 54.74952f; break;
            case 16: power = 61.546036f; break;
            case 17: power = 68.761604f; break;
            case 18: power = 75.99939f; break;
            case 19: power = 85.50663f; break;
            case 20: power = 92.92817f; break;
            case 21: power = 101.636345f; break;
            case 22: power = 111.85683f; break;
            case 23: power = 121.006775f; break;
            case 24: power = 131.18195f; break;
            case 25: power = 144.44604f; break;
            case 26: power = 153.9883f; break;
            case 27: power = 164.63615f; break;
            case 28: power = 177.93594f; break;
            case 29: power = 189.71732f; break;
            case 30: power = 204.5408f; break;
            case 31: power = 216.9668f; break;
            case 32: power = 230.57413f; break;
            case 33: power = 487.80487f; break;
            case 34: power = 522.19324f; break;
            case 35: power = 550.055f; break;
            case 36: power = 582.7506f; break;
            case 37: power = 607.5334f; break;
            case 38: power = 649.7726f; break;
            case 39: power = 677.9661f; break;
            case 40: power = 710.2273f; break;
            case 41: power = 747.9432f; break;
            case 42: power = 781.25f; break;
            case 43: power = 825.0825f; break;
            case 44: power = 853.97095f; break;
            case 45: power = 901.71326f; break;
            case 46: power = 1404.4944f; break;
            case 47: power = 1466.2756f; break;
            case 48: power = 1540.832f; break;
            case 49: power = 1602.5641f; break;
            case 50: power = 1661.1295f; break;
            case 51: power = 1733.1023f; break;
            case 52: power = 1805.0542f; break;
            case 53: power = 1865.6716f; break;
            case 54: power = 1949.3177f; break;
            case 55: power = 1992.0319f; break;
            case 56: power = 2049.1804f; break;
            case 57: power = 2898.5508f; break;
            case 58: power = 2976.1904f; break;
            case 59: power = 3076.923f; break;
            case 60: power = 3164.557f; break;
            case 61: power = 3289.4736f; break;
            case 62: power = 3367.0034f; break;
            case 63: power = 3460.2075f; break;
            case 64: power = 3610.1084f; break;
            case 65: power = 4587.156f; break;
            case 66: power = 4784.689f; break;
            case 67: power = 4901.961f; break;
            case 68: power = 5076.142f; break;
            case 69: power = 5235.602f; break;
            case 70: power = 5347.5938f; break;
            case 71: power = 5555.5557f; break;
            case 72: power = 5714.2856f; break;
            case 73: power = 6944.4443f; break;
            case 74: power = 7194.2446f; break;
            case 75: power = 7352.9414f; break;
            case 76: power = 7633.588f; break;
            case 77: power = 7751.938f; break;
            case 78: power = 7936.508f; break;
            case 79: power = 8130.0815f; break;
            case 80: power = 9803.922f; break;
            case 81: power = 10000f; break;
            case 82: power = 10101.01f; break;
            case 83: power = 10526.315f; break;
            case 84: power = 10752.688f; break;
            case 85: power = 10989.011f; break;
            case 86: power = 11235.955f; break;
            case 87: power = 12987.013f; break;
            case 88: power = 13513.514f; break;
            case 89: power = 13698.63f; break;
            case 90: power = 13888.889f; break;
            case 91: power = 14285.714f; break;
            case 92: power = 14492.754f; break;
            case 93: power = 16666.666f; break;
            case 94: power = 17241.379f; break;
            case 95: power = 17543.86f; break;
            case 96: power = 17857.143f; break;
            case 97: power = 18181.818f; break;
            case 98: power = 18867.924f; break;
            case 99: power = 20833.334f; break;
            case 100: power = 21739.13f; break;
            default: power = 21739.13f; break;
        }
        return power;
    }
    public static float GetDFactor(int level)
    {
        for (int enemyLevel = 1; enemyLevel <= level; enemyLevel++)
        {
            if (enemyLevel == 1)
            {
                dFactor = 0f;
            }
            else
            {
                dFactor += enemyLevel * 2;
            }
        }
        return dFactor;
    }
    public static float GetAFactor()
    {
        return aFactor;
    }
}
