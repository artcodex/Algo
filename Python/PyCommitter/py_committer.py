from github import Github
import sys
import time


def create_pull_req(repo):
    pull_req = algo_repo.create_pull(title="test pull", body="testing a pull request", base="master", head="pull_test")
    first_commit = pull_req.get_commits()[0]
    pull_req.create_review_comment(body="test comment 1",commit_id=first_commit, path="Python/testfile.txt", position=1)
    pull_req.create_review_comment(body="test comment 2",commit_id=first_commit, path="Python/testfile.txt", position=1)
    pull_req.create_review_comment(body="test comment 3",commit_id=first_commit, path="Python/testfile.txt", position=1)
    pull_req.edit(state="closed")

g = Github(base_url="https://git.soma.salesforce.com/api/v3", login_or_token="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")
algo_repo = g.get_user('abrenner').get_repo('AlgoData')

counter = int(sys.argv[1])
timespan = int(sys.argv[2]) * 60
ceiling = counter*60
current = 0
while current < ceiling:
  create_pull_req(algo_repo)
  time.sleep(timespan)
  current += timespan
  print ("Running for: " + str(current / 60) + " minutes")
