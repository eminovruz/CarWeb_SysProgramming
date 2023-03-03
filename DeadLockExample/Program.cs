class Program
{
    static void Main()
    {
        object Kamil = new object();
        object MirHesen = new object();

        Thread A = new Thread(() =>
        {
            lock (Kamil)
            {
                // Do something
                Thread.Sleep(1000);
                lock (MirHesen)
                {
                    // Do something
                }
            }
        });

        Thread B  = new Thread(() =>
        {
            lock (MirHesen)
            {
                // Do something
                lock (Kamil)
                {
                    // Do something
                }
            }
        });

        A.Start();
        B.Start();
    }
}

//// Explanation
/// Kamil tapsiriqi yazmayib, tenbellik edib deyirki:
///     -- Qoy MirHesen yazsin, mende onnan kocurderem
/// Ama MirHesen tapsiriqi yazmayib , oda bele dusunurki
///     -- Qoy Kamil yazsin, men onnan kocurderem
/// Xeberleri olmasada, onlar bir tip deadlockdadilar. Yeni her ikisi sonsuza dek bir birini gozluyecek ama bunnan xeberleri yoxdu :) 

