class Program
{
    static void Main()
    {
        object Nihat = new object();
        object Royal = new object();

        Thread A = new Thread(() =>
        {
            lock (Nihat)
            {
                // Do something
                Thread.Sleep(1000);
                lock (Royal)
                {
                    // Do something
                }
            }
        });

        Thread B  = new Thread(() =>
        {
            lock (Royal)
            {
                // Do something
                lock (Nihat)
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
/// Nihat tapsiriqi yazmayib, tenbellik edib deyirki:
///     -- Qoy royal yazsin, mende onnan kocurderem
/// Ama Royalda tapsiriqi yazmayib , oda bele dusunurki
///     -- Qoy nihat yazsin, men onnan kocurderem
/// Xeberleri olmasada, onlar bir tip deadlockdadilar. Yeni her ikisi sonsuza dek bir birini gozluyecek ama bunnan xeberleri yoxdu :) 

