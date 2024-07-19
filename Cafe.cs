using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Task3;

namespace Task3
{
    internal class Cafe
    {
        Queue<Visitor> _waitingVisitors = new Queue<Visitor>();

        Visitor[] _currentVisitors;

        int _currentVisitorsPosition = 0;

        public Cafe(int maxClients)
        {
            _currentVisitors = new Visitor[maxClients];
        }
        public void AddClient(Visitor visitor)
        {
            if (visitor is null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            if (_currentVisitorsPosition < _currentVisitors.Length)
            {
                _currentVisitors[_currentVisitorsPosition++] = visitor;
            }
            else
            {
                _waitingVisitors.Enqueue(visitor);
            }
        }

        public void AddClient(Visitor visitor, DateTime dateTime)
        {
            if (visitor is null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            if (_currentVisitorsPosition < _currentVisitors.Length - 1)
            {
                _currentVisitors[_currentVisitorsPosition++] = visitor;
            }
            else
            {
                throw new Exception("All the tables were already reserved");
            }
        }

        public void RemoveClient(Visitor visitor)
        {
            if (visitor is null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            for (int i = 0; i < _currentVisitors.Length; i++)
            {
                if (_currentVisitors[i].Fullname == visitor.Fullname)
                {
                    for (int j = i; j < _currentVisitors.Length - 1; j++)
                    {
                        _currentVisitors[j] = _currentVisitors[j + 1];
                    }
                    _currentVisitorsPosition--;
                    if (_waitingVisitors.Count > 0)
                    {
                        _currentVisitors[_currentVisitorsPosition++] = _waitingVisitors.Dequeue();
                    }
                    return;
                }
            }
            throw new InvalidOperationException("there is no client by that name");
        }

        public Visitor[] GetCurrentVisitors()
        {
            return _currentVisitors.Take(_currentVisitorsPosition).ToArray();
        }

        public Visitor[] GetVisitorsInQueue() 
        {
            return _waitingVisitors.ToArray();
        }
    }
}

//Создайте приложение, эмулирующее очередь в популярное кафе. 
//Посетители кафе приходят и попадают в очередь, если нет свободного места. 
//При освобождении столика в кафе, первый посетитель очереди занимает его. 
//Если приходит клиент, который резервировал столик на определенное время, он получает зарезервированный столик вне очереди.
//При разработке приложения используйте класс Queue<T>.
