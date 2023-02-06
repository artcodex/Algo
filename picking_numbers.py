#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'pickingNumbers' function below.
#
# The function is expected to return an INTEGER.
# The function accepts INTEGER_ARRAY a as parameter.
#

def pickingNumbers(a):
    max_run = 1
    num_counts = {}
    for i in range(101):
        num_counts[i] = 0
    for i in range(len(a)):
        num_counts[a[i]] += 1
    for i in range(len(a)):
        sum_value = num_counts[a[i]] + num_counts[a[i] + 1]
        if sum_value > max_run:
            max_run = sum_value

    return max_run

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input().strip())

    a = list(map(int, input().rstrip().split()))

    result = pickingNumbers(a)

    fptr.write(str(result) + '\n')

    fptr.close()

