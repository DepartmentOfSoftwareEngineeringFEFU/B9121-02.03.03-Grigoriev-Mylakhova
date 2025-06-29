# Информация
Тема диплома: Разработка программного средства для обустройства интерьера с использованием технологий смешанной и дополненной реальности.

Автор: Григорьев Алексей Алексеевич(back) и Мылахова Светлана Альбертовна(front).

Группа: Б9121-02.03.03тп

Научный руководитель: Профессор ДПИиИИ, д.т.н., профессор И. Л. Артемьева

# Описание проекта
Программное средство для проектирования и обустройства интерьеров с использованием технологий дополненной (AR) и смешанной реальности (MR) . Приложение позволяет пользователям визуализировать мебель в реальном пространстве, настраивать параметры объектов, собирать мебель в виртуальной среде и сохранять проекты.

# Компоненты проекта
Unity m_EditorVersion: 6000.0.46f1

Android SDK API Level 33–35 (android-35)

AR Foundation	


ARCore XR Plugin


Firebase SDK	Unity SDK 


C#	.NET Standard 2.1

Gradle	Managed by Unity


Backend	MAMP (Apache + MySQL + PHP)


PHP	


MySQL	


phpMyAdmin	В составе MAMP

# Инструкция
1. Установить Unity Hub: https://unity.com/download. Через него установить нужную версию Unity. Добавить Android Build Support + OpenJDK + SDK & NDK Tools во время установки.

2.  MAMP (для PHP и MySQL)
Скачать MAMP: https://www.mamp.info/en/. Запустить: Apache (порт 8888) MySQL (порт 8889). Поместить свой серверный код (PHP-файлы) в папку htdocs: C:\MAMP\htdocs\your-backend-folder\.

3. Скачать Firebase SDK для Unity в .tgz-формате:https://firebase.google.com/download/unity. В Unity открыть Window → Package Managerю Нажать "+" → Add package from tarball. Указать путь к следующим файлам: com.google.firebase.app-12.1.0.tgz и  com.google.external-dependency-manager-<версия>.tgz.

4. Настройка проекта: В Unity: открыть проект через Unity Hub. Установить нужные пакеты в Window → Package Manager: AR Foundation.  ARCore XR Plugin.

5. в Unity открыть В Player Settings: File → Build Settings → Android → Switch Platform. Затем в Edit → Project Settings → Player: Указать Package Name: com.DefaultCompany.test1. Target API Level: Android 34. Включить AR Support (XR Plug-in Management → ARCore)

6. Подготовка к сборке на Android. Подключить Android-устройство через USB (отладка включена). Проверить в Build Settings, что сцены добавлены. Нажать Build and Run 7. Запуск сервера. Открой http://localhost/unityapi/

# Запуск на Android
Чтобы пользователь смог запустить проект, смартфон должен: Минимум ОС	Android 9.0 (Pie) или новее. Поддержка AR	Обязательно поддержка ARCore от Google. Свободное место	1+ ГБ на установку и кэш
