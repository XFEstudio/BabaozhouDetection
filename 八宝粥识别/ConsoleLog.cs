using System.Collections;
using XFE各类拓展.NetCore.DelegateExtension;

namespace 八宝粥识别;

public class ConsoleLog : IList<string>
{
    private readonly List<string> LogList = [];

    public string this[int index] { get => ((IList<string>)LogList)[index]; set => ((IList<string>)LogList)[index] = value; }

    public int Count => ((ICollection<string>)LogList).Count;
    public int MaxCount { get; set; }

    public bool IsReadOnly => ((ICollection<string>)LogList).IsReadOnly;

    public event XFEEventHandler<ConsoleLog, string>? LogAdded;

    public void Add(string logText)
    {
        ((ICollection<string>)LogList).Add(logText);
        if (LogList.Count > MaxCount)
            LogList.RemoveAt(0);
        LogAdded?.Invoke(this, logText);
    }

    public void Clear() => ((ICollection<string>)LogList).Clear();

    public bool Contains(string logText) => ((ICollection<string>)LogList).Contains(logText);

    public void CopyTo(string[] array, int arrayIndex) => ((ICollection<string>)LogList).CopyTo(array, arrayIndex);

    public IEnumerator<string> GetEnumerator() => ((IEnumerable<string>)LogList).GetEnumerator();

    public int IndexOf(string logText) => ((IList<string>)LogList).IndexOf(logText);

    public void Insert(int index, string logText) => ((IList<string>)LogList).Insert(index, logText);

    public bool Remove(string logText) => ((ICollection<string>)LogList).Remove(logText);

    public void RemoveAt(int index) => ((IList<string>)LogList).RemoveAt(index);

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)LogList).GetEnumerator();
}
