// Класс с событием
public class FirstClass{
    public delegate void Event(string name);

    // Событие, с типом делегата EventHandler
    public event Event OnEvent;

    // Текстовое поле для хранения имени объекта
    public string Name { get; }

    // Конструктор инициализирует имя объекта
    public FirstClass(string name){
        Name = name;
    }

    // Метод для активации события
    public void TriggerEvent(){
        OnEvent?.Invoke(Name);
    }
}

// Второй класс с методом-обработчиком
public class SecondClass{
    // Метод-обработчик с текстовым аргументом
    public void EventAct(string nameOfObject){
        Console.WriteLine($"Событие активировано объектом: {nameOfObject}");
    }
}

class Program{
    static void Main(string[] args){
        // Создание объектов первого и второго класса
        FirstClass firstObject = new FirstClass("Первый Объект");
        FirstClass secondObject = new FirstClass("Второй Объект");
        SecondClass handlerObject = new SecondClass();

        // Регистрация метода из SecondClass как обработчика для событий объектов FirstClass
        firstObject.OnEvent += handlerObject.EventAct;
        secondObject.OnEvent += handlerObject.EventAct;

        // Активация событий
        firstObject.TriggerEvent();
        secondObject.TriggerEvent();
    }
}