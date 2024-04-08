using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Novo Dialogo", menuName = "Novo Dialogo/Dialogo")]
public class ConfiguracaoDialogo : ScriptableObject
{
    [Header("Configuracao")]
    public GameObject ator;

    [Header("Dialogo")]
    public Sprite falaSprite;
    public string sentenca;

    public List<Sentencas> dialogos = new List<Sentencas>();
}

[System.Serializable]
public class Sentencas
{
    public string atorNome;
    public Sprite Perfil;
    public Linguagem sentenca;
}

[System.Serializable]
public class Linguagem
{
    public string portugues;
    public string english;
}

#if UNITY_EDITOR

[CustomEditor(typeof(ConfiguracaoDialogo))]
public class ConstrucaoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ConfiguracaoDialogo cd = (ConfiguracaoDialogo)target;

        Linguagem lang = new Linguagem();
        lang.portugues = cd.sentenca;

        Sentencas sent = new Sentencas();
        sent.Perfil = cd.falaSprite;
        sent.sentenca = lang;

        if (GUILayout.Button("Criar Diálogo"))
        {
            if(cd.sentenca != "")
            {
                cd.dialogos.Add(sent);

                cd.falaSprite = null;
                cd.sentenca = "";
            }
        }
    }
}

#endif
