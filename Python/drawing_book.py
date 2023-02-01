#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'pageCount' function below.
#
# The function is expected to return an INTEGER.
# The function accepts following parameters:
#  1. INTEGER n
#  2. INTEGER p
#

def pageCount(n, p):
    # Write your code here
    flips = 0
    add = 1
    
    if (n % 2 != 0):
        add = 0
    
    for i in range(1,n+1,2):
        if (p == i or p == i-1):
            break
        if (p == (n-i)+add or p == (n-i)+1+add):
            break
            
        flips += 1
        
    return flips
    

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input().strip())

    p = int(input().strip())

    result = pageCount(n, p)

    fptr.write(str(result) + '\n')

    fptr.close()

