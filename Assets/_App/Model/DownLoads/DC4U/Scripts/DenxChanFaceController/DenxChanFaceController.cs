using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class DenxChanFaceController : MonoBehaviour {

    /*
    参考にしたやつ：http://www.gogogogo.jp/issue/diary/%E4%B8%80%E4%BA%BA%E5%A4%A7%E5%AD%A6/unity4/3264/
    個別に各シェイプをいじりたいなら↑の方法でSkinnedMeshRendererを直接制御するのがいいと思います
    */

    public SkinnedMeshRenderer skinnedMeshRenderer;
    public bool blink;

    //シェイプ名とインデックスを格納する
    private Dictionary<int, string> dicts;

    // Use this for initialization
    void Start () {
        if(this.skinnedMeshRenderer != null) {
            dicts = GetIndexes(skinnedMeshRenderer);
            UpdateToNormal();
        }
        if (blink)
        {
            StartCoroutine("Blinking");
        }
	}
	
    public void UpdateToNormal()
    {
        Reset();
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("close mouth"),95);
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("close L eye"), 15);
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("close R eye"), 15);
    }

    public void CloseEye()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("close L eye"), 100);
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("close R eye"), 100);
    }

    public void OpenEye()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("close L eye"), 0);
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("close R eye"), 0);
    }

    public void UpdateToSmile(float weight)
    {
        Reset();
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("smile"), weight);
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("curve L eye"), weight);
        skinnedMeshRenderer.SetBlendShapeWeight(GetFaceIndex("curve R eye"), weight);
    }

	// Update is called once per frame
	void Update () {
        //UpdateToSmile(100);
	}

    private Dictionary<int,string> GetIndexes(SkinnedMeshRenderer skm)
    {
        var dicts = Enumerable.Range(0, skm.sharedMesh.blendShapeCount).ToDictionary(n => n, n => skm.sharedMesh.GetBlendShapeName(n));
        return dicts;
    }

    private int GetFaceIndex(string s)
    {
        return dicts.Where(v => v.Value == s).Select(v => v.Key).First();
    }

    public void Reset()
    {
        foreach (var e in dicts)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(e.Key, 0);
        }
    }

    private IEnumerator Blinking()
    {
        while (true)
        {
            CloseEye();
            yield return new WaitForSeconds(0.05f);
            OpenEye();
            yield return new WaitForSeconds(Random.Range(0.5f, 3.0f));
        }
    }
}
