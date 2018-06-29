using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lib
{
    public class DUlib
    {
        public static Color randColor()
        {
            return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        public static Color randMainColor() {
            return new Color(Random.Range(0.65f, 0.9f), Random.Range(0f, 0.2f), Random.Range(0.65f, 0.9f), Random.Range(0.25f, 1f));
        }
        public static Color setAlpha() {
            return new Color();
        }
        public static void Hello()
        {
 
        }
    }
}
