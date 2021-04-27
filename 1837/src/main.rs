// 1837. Sum of Digits in Base K
// https://leetcode.com/problems/sum-of-digits-in-base-k/
fn main() {
    assert_eq!(sum_base(34, 6), 54);
    assert_eq!(sum_base(10, 10), 1);
}

pub fn sum_base(mut n: i32, k: i32) -> i32 {
    let mut sum = 0;

    while n != 0 {
        sum = sum + n % k;
        n = n / k;
    }

    sum
}
