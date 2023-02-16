import os
import sys
import time
import subprocess

def commit_word():
    index = 0
    j = 0
    word = ""

    with open('current.txt') as index_file:
        index = int(next(index_file))

    with open('words.txt') as word_file:
        for line in word_file:
            word=line
            if j==index:
                break;

            j += 1

    print(word)

    with open('written.txt','a') as written:
        written.write(word)

    with open('current.txt', 'w') as index_file:
        index_file.writelines(str(index+1))

    subprocess.run('git add .', shell=True)
    subprocess.run('git commit -m "Adding word ' + word + '"', shell=True) 
    subprocess.run('git push origin master', shell=True)
    subprocess.run('git push public master', shell=True)


counter = int(sys.argv[1])
timespan = int(sys.argv[2]) * 60
ceiling = counter*3600
current = 0
while current < ceiling:
    commit_word()
    time.sleep(timespan)
    current += timespan
    print ("Running for: " + (current / 60) + " minutes")
