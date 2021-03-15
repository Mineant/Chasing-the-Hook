using UnityEngine;
using UnityEditor;
using System;

namespace AmazingAssets.RenderMonster
{
    public class RenderMonsterKeyCodeWindow : EditorWindow
    {
        static RenderMonsterKeyCodeWindow window;

        public delegate void UpdateKeyCode(KeyCode keyCode);
        static UpdateKeyCode ApplyKeyCode;


        static public void ShowWindow(Vector2 _pos, UpdateKeyCode _func)
        {
            ApplyKeyCode = _func;

            window = (RenderMonsterKeyCodeWindow)RenderMonsterKeyCodeWindow.CreateInstance(typeof(RenderMonsterKeyCodeWindow));

            window.Focus();
            window.ShowAsDropDown(new Rect(_pos.x, _pos.y, 0, 0), new Vector2(250, 45));
        }

        void OnLostFocus()
        {
            this.Close();
        }

        void OnGUI()
        {
            //window is lost 
            if (window == null)
            {
                if (this != null)
                    this.Close();

                return;
            }


            EditorGUILayout.HelpBox("Press any key on the keyboard", MessageType.Warning);

            if (Event.current != null)
            {
                if (Event.current.keyCode == KeyCode.Escape)
                {
                    window.Close();
                    return;
                }

                if (Event.current.isKey)
                {
                    ApplyKeyCode(Event.current.keyCode);

                    window.Close();
                    return;
                }
            }
        }
    }

}
