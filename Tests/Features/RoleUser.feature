Feature: RoleUser

A short summary of the feature

Scenario: Create, Get,  Delete  Role User record
  When I send RoleUser "POST" request for "<Version>" with payload parameters
    | WorkflowRoleId   | Id    | Email   |
    | <WorkflowRoleId> | <Id>  | <Email> |
  Then I validate request <StatusCode>
  And I validate response has id
  When I input "<WorkflowRoleId>" in Query parameters and send "GET" all RoleUser request for "<Version>"
  Then I validate request <StatusCode>
  When I input RoleUserId as path parameter and "<WorkflowRoleId>" in Query parameters and send "DELETE" request for "<Version>"
  Then I validate request <StatusCode>

  Examples:
  | WorkflowRoleId | Id                                     | UserName         | Email                        | Version | StatusCode |
  | 20             | b43e1439-62a4-42e2-80f7-58917d6b280c   | autotest         | Test@test.com      | V1.0    | 200        |
  | 18             | b43e1439-62a4-42e2-80f7-58917d6b280c   | autotest         | Test@test.com      | V1.0    | 200        |
