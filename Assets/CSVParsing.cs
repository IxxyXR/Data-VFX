using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.VFX;

public class CSVParsing : MonoBehaviour
{

    public TextAsset csvFile;
    public int ColumnNumber = 3;
    public string VFXParameterName = "CSVData";

    private VisualEffect VFX;
    private List<float> data;
    private char lineSeperater = '\n';
    private char fieldSeperator = ',';
    private int currentRow;

    void Start()
    {
        VFX = gameObject.GetComponent<VisualEffect>();
        data = new List<float>();
        readData();
        currentRow = 0;
    }

    private void readData()
    {
        List<string> records = csvFile.text.Split(lineSeperater).ToList();
        records.RemoveAt(0);
        foreach (string record in records)
        {
            string[] fields = record.Split(fieldSeperator);
            data.Add(float.Parse(fields[ColumnNumber]));
        }
    }

    public void Update()
    {
        if (data == null) return;
        VFX.SetFloat(VFXParameterName, data[currentRow]);
        currentRow++;
        currentRow %= data.Count;
    }

}