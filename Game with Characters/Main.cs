using Game_with_Characters;

{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Введите количество персонажей: ");
        int numberOfCharacters = int.Parse(Console.ReadLine());

        Character[] characters = new Character[numberOfCharacters];

        for (int i = 0; i < numberOfCharacters; i++)
        {
            Console.WriteLine($"Персонаж {i + 1}:");

            Console.Write("Имя: ");
            string name = Console.ReadLine();

            Console.Write("X координата: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Y координата: ");
            int y = int.Parse(Console.ReadLine());

            Console.Write("Является другом (true/false): ");
            bool isFriend = bool.Parse(Console.ReadLine());

            Console.Write("Здоровье: ");
            int health = int.Parse(Console.ReadLine());

            Console.Write("Урон: ");
            int damage = int.Parse(Console.ReadLine());
            Console.WriteLine();

            characters[i] = new Character(name, x, y, isFriend, health, damage);
        }

        int choice;
        do
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("1. Вывести информацию о персонаже ");
            Console.WriteLine("2. Переместить персонажа по горизонтали ");
            Console.WriteLine("3. Переместить персонажа по вертикали ");
            Console.WriteLine("4. Уничтожить персонажа ");
            Console.WriteLine("5. Нанести урон персонажу ");
            Console.WriteLine("6. Лечение персонажа ");
            Console.WriteLine("7. Полное восстановление персонажа ");
            Console.WriteLine("8. Изменить лагерь персонажа ");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("0. Выход");
            Console.WriteLine();

            Console.Write("Выберите действие: ");
            choice = int.Parse(Console.ReadLine());

            int characterIndex;

            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Введите номер персонажа: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        if (characters[characterIndex].IsAlive())
                        {
                            characters[characterIndex].Info();
                        }
                        else
                        {
                            Console.WriteLine("Персонаж уничтожен и не может быть отображен.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа.");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 2:
                    Console.Write("Введите номер персонажа: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        Console.Write("Введите смещение по X: ");
                        int dx = int.Parse(Console.ReadLine());
                        characters[characterIndex].MoveX(dx);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа.");
                    }
                    break;
                case 3:
                    Console.Write("Введите номер персонажа: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        Console.Write("Введите смещение по Y: ");
                        int dy = int.Parse(Console.ReadLine());
                        characters[characterIndex].MoveY(dy);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа.");
                    }
                    break;
                case 4:
                    Console.Write("Введите номер персонажа: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        characters[characterIndex].Destroy();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа.");
                    }
                    break;
                case 5:
                    Console.Write("Введите номер персонажа, наносящего урон: ");
                    int attackerIndex = int.Parse(Console.ReadLine()) - 1;
                    if (attackerIndex >= 0 && attackerIndex < numberOfCharacters && characters[attackerIndex].IsAlive())
                    {
                        Console.Write("Введите номер цели: ");
                        int targetIndex = int.Parse(Console.ReadLine()) - 1;
                        if (targetIndex >= 0 && targetIndex < numberOfCharacters && characters[targetIndex].IsAlive())
                        {
                            characters[attackerIndex].InfoLictDamage(characters[attackerIndex].GetDamage(), characters[targetIndex]);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный номер цели или цель уже уничтожена.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа-атакующего или атакующий уже уничтожен.");
                    }
                    break;
                case 6:
                    Console.Write("Введите номер персонажа: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        Console.Write("Введите количество лечения: ");
                        int healing = int.Parse(Console.ReadLine());
                        characters[characterIndex].Heal(healing);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа.");
                    }
                    break;
                case 7:
                    Console.Write("Введите номер персонажа: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        characters[characterIndex].FullHealAgain();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа.");
                    }
                    break;
                case 8:
                    Console.Write("Введите номер персонажа: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        characters[characterIndex].ChangeCamp();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа.");
                    }
                    break;
                case 0:
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }

        } while (choice != 0);
    }
}