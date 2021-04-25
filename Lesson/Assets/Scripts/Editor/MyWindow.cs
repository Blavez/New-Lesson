using UnityEditor;
using UnityEngine;

namespace Geekbrains
{
    public class MyWindow : EditorWindow
    {
        public static GameObject ObjectInstantiate;
        public string _nameObject = "Hello World";
        public bool _groupEnabled;
        public bool _randomColor = true;
        public int _countObject = 1;
        public float _radius = 10;
        public float coordinateX = 10;
        public float coordinateY = 10;
        public float coordinateZ = 10;

        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            ObjectInstantiate =
               EditorGUILayout.ObjectField("Объект который хотим вставить",
                     ObjectInstantiate, typeof(GameObject), true)
                  as GameObject;
            _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
            _groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
               _groupEnabled);

            _randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
            _countObject = EditorGUILayout.IntSlider("Количество объектов",
               _countObject, 1, 100);
            _radius = EditorGUILayout.Slider("Радиус окружности", _radius, 10, 50);
            coordinateX = EditorGUILayout.Slider("Координата X", coordinateX, 230, 250);
            coordinateY = EditorGUILayout.Slider("Координата Y", coordinateY, 1, 2);
            coordinateZ = EditorGUILayout.Slider("Координата Z", coordinateZ, 930, 940);
            EditorGUILayout.EndToggleGroup();
            var button = GUILayout.Button("Создать объект(ы)");
            if (button)
            {
                if (ObjectInstantiate)
                {
                    GameObject root = new GameObject("Root");
                    for (int i = 0; i < _countObject; i++)
                    {
                        float angle = i * Mathf.PI * 2 / _countObject;
                        Vector3 pos = new Vector3(coordinateX, coordinateY,
                                         coordinateZ) * _radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos,
                           Quaternion.identity);
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        var tempRenderer = temp.GetComponent<Renderer>();
                        if (tempRenderer && _randomColor)
                        {
                            tempRenderer.material.color = Random.ColorHSV();
                        }
                    }
                }
            }
        }
    }
}