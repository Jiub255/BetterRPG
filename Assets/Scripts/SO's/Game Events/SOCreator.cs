using UnityEditor;
using UnityEngine;

public class SOCreator
{

    #region CompileTime
    public class WhatAClassCT<W, A, C>
    {
        public W val1;
        public A val2;
        public C val3;

        public WhatAClassCT(W val1, A val2, C val3)
        {
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
        }

        public override string ToString()
        {
            return val1.ToString() + " " + val2.ToString() + " " + val3.ToString();
        }
    }

    [MenuItem("Assets/SOCompileTime")]
    public static void CreateAssetCT()
    {
        var so = ScriptableObject.CreateInstance<ScriptableObjectGenerics>();

        //Compile-time
        WhatAClassCT<int, string, System.Action> wacCT = new WhatAClassCT<int, string, System.Action>(10, "Generics", () => { Debug.Log("Are Cool"); });
        Debug.Log("Compile time : ");
        Debug.Log("Creation : " + wacCT);

        so.Set(wacCT);

        wacCT = null;
        Debug.Log("Removal : " + wacCT);

        wacCT = so.Get<WhatAClassCT<int, string, System.Action>>();
        Debug.Log("Retrival : " + wacCT);
        Debug.Log(wacCT.val2);
        wacCT.val3.Invoke();
    }
    #endregion

    #region RunTime
    public class WhatAClassRT
    {
        public System.Object val1;
        public System.Object val2;
        public System.Object val3;

        public WhatAClassRT(System.Object val1, System.Object val2, System.Object val3)
        {
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
        }

        public override string ToString()
        {
            return val1.ToString() + " " + val2.ToString() + " " + val3.ToString();
        }
    }

    [MenuItem("Assets/SORunTime")]
    public static void CreateAssetRT()
    {
        var so = ScriptableObject.CreateInstance<ScriptableObjectGenerics>();

        //Run-time
        WhatAClassRT wacRT = new WhatAClassRT(10, "Generics", (System.Action)(() => { Debug.Log("Are Cool"); }));
        Debug.Log("Run time : ");
        Debug.Log("Creation : " + wacRT);

        so.Set(wacRT);

        wacRT = null;
        Debug.Log("Removal : " + wacRT);

        wacRT = so.Get<WhatAClassRT>();
        Debug.Log("Retrival : " + wacRT);
        Debug.Log(wacRT.val2);
        ((System.Action)wacRT.val3).Invoke();
    }

    #endregion
}