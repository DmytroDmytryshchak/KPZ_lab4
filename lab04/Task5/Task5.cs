using System;
using System.Collections.Generic;

namespace Task5
{
    public static class Task5
    {
        public static void Run()
        {
            var editor = new TextEditor();

            editor.Write("Hello ");
            editor.Write("world!");
            editor.Show();

            editor.Undo();
            editor.Show();

            editor.Undo();
            editor.Show();
        }
    }

    class TextDocument
    {
        public string Content;
    }

    class Memento
    {
        public string State;
        public Memento(string s) => State = s;
    }

    class TextEditor
    {
        private TextDocument doc = new TextDocument();
        private Stack<Memento> history = new Stack<Memento>();

        public void Write(string text)
        {
            history.Push(new Memento(doc.Content));
            doc.Content += text;
        }

        public void Undo()
        {
            if (history.Count > 0)
                doc.Content = history.Pop().State;
        }

        public void Show()
        {
            Console.WriteLine("Document: " + doc.Content);
        }
    }
}