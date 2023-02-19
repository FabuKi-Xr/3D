def cast(input : str) -> int:
    result = 0
    numberstr = ""
    #delete non number
    for i in range(len(input)):
        if input[i] in "0123456789":
            numberstr += input[i]
    print(numberstr)
    #change str to int
    for i in range(len(numberstr)):
        result += int(numberstr[i]) * 10 ** (len(numberstr)-i-1)
    return result
print(cast(input('enter string :')))
