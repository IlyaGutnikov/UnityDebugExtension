### Unity Debug Extension

Данное расширение позволяет гибче настраивать процесс логирования в Unity при помощи специальных тегов и цветовой индикации.


## Установка

Скопируйте содержимое Assets из этого проекта в Ваш проект.

## Управление тегами

Управление тегами осуществляется при помощи меню, которое вызывается при помощи `Tools/DebugPrefixes`.

# Назначение кнопок:

* Refresh - обновляет список тегов. Пустой тег будет автоматически удален из списка;
* Save - сохраняет список тегов и список включеных тегов в сериализуемый объект;
* (Re)Create Enum - создает или пересоздает Enum тегов;
* Add item добавляет новый тег в список;
* Галочка в чекбоксе включет тег. Выключенные теги не будут отображаться в консольном выводе.

# Пример использования
Данный код, выведет сообщение 1234567890, если тег `test` включен в окне выбора тегов.
`Debug.LogError(DebugPrefixEnum.test, "1234567890".Colored(Colors.brown));`

# Примечание

Добавлено расширение для строк, которое позволяет делать их цветными. Взято отсюда: http://www.tallior.com/pimp-my-debug-log/
